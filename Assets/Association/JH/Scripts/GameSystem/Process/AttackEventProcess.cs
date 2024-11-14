using System;
using UnityEngine;
using static BattleEventProcessor;

public static class BattleEventProcessor
{
    // 일반 공격 진행
    public static void TryBattleActionProcess(IAttacker Attacker, IDefender Defender)
    {
        try
        {
            Attacker.CastAttack();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    //static public void TrySkillCastProcess(ISkillAttacker Attacker, IDefender Defender)
    //{
    //    Attacker.CastAttackDelay();
    //    Action action = () => {; };
    //    action += () => Attacker.Attack();
    //    action += () => Attacker.RecoveryDelay();
    //}


    // 일반 공격 데미지 계산 진행


    public interface IBattleRole
    {
        string Name { get; }

        int CurrentHP { get; set; }
        int GetProperty<T>() where T : BattleProperty;
    }
}


public interface IAttacker : IBattleRole
{
    ISkill SkillData { get; }

    // TODO : 공격 추가 액션 (ex 나미 e)
    // public Action<IDefender> DamagingAction { get; set; }

    void CastAttack()
    {
    }
}

public interface IDefender : IBattleRole
{
    // 기타동작
    // Action Action { get; }
}

public interface ActionPacket
{
    Action OnStartAction { get; }
    Action<object> OnCastAction { get; }
    Action OnExitAction { get; }
}

public struct CharacterBattleActionPacket : ActionPacket
{
    public Action OnStartAction { get; }
    public Action<object> OnCastAction { get; }
    public Action OnExitAction { get; }

    public CharacterBattleActionPacket(MainGameCharacter Attacker, Action<object> castAction)
    {
        OnStartAction = Attacker.GetStateMachine.Event_Attack;
        OnCastAction = castAction;
        OnExitAction = Attacker.GetStateMachine.Event_TimeToIdle;
    }
}