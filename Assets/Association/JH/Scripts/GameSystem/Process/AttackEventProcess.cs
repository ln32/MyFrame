using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static BattleEventProcessor;

public static class BattleEventProcessor
{
    // 일반 공격 진행
    static public void TryAttackProcess(IMeleeAttacker Attacker, IDefender Defender)
    {
        try
        {
            if (Attacker.IsAvailable() == false)
                throw new ArgumentException("Not Available");

            Attacker.CastAttackDelay();


            Action action = () => {;};
            action += () => Attacker.Attack();
            action += () => Attacker.RecoveryDelay();
            action.Invoke();

            Attacker.IAttackInfo.ApplyCastDelay(Defender);

        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    static public void OnHitAttackProcess(IMeleeAttacker Attacker, IDefender Defender)
    {
        Debug.Log(Attacker.Name + " attack " + Defender.Name);
        // 상대 존재    

        /// 공격 적중 여부 계산
        // 명중 계산
        // 회피 계산

        // 최종 데미지 계산 (치명타 계산)
        // 데미지 증감율 계산

        // HP 감소 계산
        // 사망 판정
    }

    //static public void TrySkillCastProcess(ISkillAttacker Attacker, IDefender Defender)
    //{
    //    Attacker.CastAttackDelay();
    //    Action action = () => {; };
    //    action += () => Attacker.Attack();
    //    action += () => Attacker.RecoveryDelay();
    //}



    //static public void OnHitSkillProcess(ISkillAttacker Attacker, IDefender Defender)
    //{
    //    // 상대 존재

    //    // 스킬 최종 데미지 계산
    //    // 데미지 증감율 계산 (방어)

    //    // HP 감소 계산
    //    // 사망 판정
    //}

    // 일반 공격 데미지 계산 진행



    public interface IBattleRole
    {
        string Name { get; }
        int GetProperty<T>() where T : BattleProperty;
    }

    public interface IMeleeAttacker : IBattleRole
    {
        IAttackInfo IAttackInfo { get; }
        virtual bool IsAvailable() { return IAttackInfo.IsAvailable(); }

        virtual void CastAttackDelay()
        {
            Debug.Log("Basic_Atk_Dmg_BattleProperty " + GetProperty<Basic_Atk_Dmg_BattleProperty>());
        }

        virtual void Attack()
        {
            Debug.Log("AttackProcess ATK_SPD " + GetProperty<ATK_SPD_BattleProperty>());
        }

        virtual void RecoveryDelay()
        {
            Debug.Log("RecoveryDelay " + GetProperty<ATK_SPD_BattleProperty>());
        }
    }

    public interface IDefender : IBattleRole
    {
        // 기타동작
        // Action Action { get; }
    }
}

public interface IAttackInfo
{
    virtual bool IsAvailable()
    {
        Debug.Log("IsAvailable ");
        return true;
    }

    virtual void ApplyCastDelay(IDefender Defender)
    {
        Debug.Log("ApplyCastDelay ");
    }

    virtual void OnWork(IDefender Defender)
    {
        Debug.Log("OnWork");
    }

    virtual void ApplyRecoveryDelay()
    {
        Debug.Log("RecoveryDelay");
    }
}


public class DefaultAttackInfo : IAttackInfo
{
    CharacterAttacker character;

    public DefaultAttackInfo(CharacterAttacker _character)
    {
        character = _character;
    }

    public float CastDelayTime { get; set; } = 1;
    public float AttackGapTime { get; set; } = 2;
    public float RecoveryDelayTime { get; set; } = 1;


    public bool IsAvailable()
    {
        return character.LastAttackTime + AttackGapTime < Time.time;
    }

    public void ApplyCastDelay(IDefender Defender)
    {
        Action temp = () =>
        {
            Debug.Log("ApplyCastDelay : " + CastDelayTime);
            OnWork(Defender); ApplyRecoveryDelay();
        };
        character.CharacterDelayMsg(CastDelayTime, temp);
    }

    public void OnWork(IDefender Defender)
    {
        character.LastAttackTime = Time.time;

        OnHitAttackProcess(character, Defender);
    }

    public void ApplyRecoveryDelay()
    {
        Action temp = () =>
        {
            Debug.Log("ApplyRecoveryDelay : " + RecoveryDelayTime);
        };
        character.CharacterDelayMsg(RecoveryDelayTime, temp);
    }
}

public class CharacterAttacker : IMeleeAttacker
{
    MainGameCharacter character;
    List<IBattlePropertyComposition> specList = new();
    public string Name { get; }
    public IAttackInfo IAttackInfo { get; }

    public float LastAttackTime = 0;


    public CharacterAttacker(MainGameCharacter _character, IAttackInfo _IAttackInfo = null)
    {
        character = _character;
        Name = character.name;

        specList.Add(character.EquipItemPlatform);
        specList.Add(character.AchievementSpec);
        specList.Add(character.CharacterTypeSpec);

        IAttackInfo = new DefaultAttackInfo(this);
    }

    public int GetProperty<T>() where T : BattleProperty
    {
        int sum = 0;

        foreach (var item in specList)
        {
            sum += item.GetProperty<T>();
        }

        return sum;
    }


    public void CharacterDelayMsg(float delay, Action action)
    {
        character.DelayMsg(delay, action);
    }
}

public class CharacterDefender : IDefender
{
    MainGameCharacter character;
    List<IBattlePropertyComposition> specList = new();
    public string Name { get; }
    public IAttackInfo IAttackInfo { get; }

    public float LastAttackTime = 0;


    public CharacterDefender(MainGameCharacter _character)
    {
        character = _character;
        Name = character.name;

        specList.Add(character.EquipItemPlatform);
        specList.Add(character.AchievementSpec);
        specList.Add(character.CharacterTypeSpec);
    }

    public int GetProperty<T>() where T : BattleProperty
    {
        int sum = 0;

        foreach (var item in specList)
        {
            sum += item.GetProperty<T>();
        }

        return sum;
    }


    public void CharacterDelayMsg(float delay, Action action)
    {
        character.DelayMsg(delay, action);
    }
}