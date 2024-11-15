<<<<<<< HEAD
    ====== =
using SkillAffactCase;
using SkillProcess;
>>>>>>> 5b6471c(fix #137)
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
    <<<<<<<HEAD
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

        ====== =HEAD

        public interface IBattleRole
        {
            b6471c(fix #137)
            string Name { get; }
            int CurrentHP { get; set; }

            int GetProperty<T>() where T : BattleProperty;
                >>>>>>> 5

            int GetProperty<T>() where T : BattleProperty;
        }
        <<<<<<<
    }

    ====== =
}
>>>>>>> 5b6471c(fix #137)

public interface IAttacker : IBattleRole
{
    b6471c(fix #137)

    ISkill SkillData { get; }

    // TODO : 공격 추가 액션
    // public Action<IDefender> DamagingAction { get; set; }

    <<<<<<<HEAD

    void CastAttack()
    {
    }
    ====== =

    void CastAttack();
        >>>>>>> 5
}

public interface IDefender : IBattleRole
{
    // 기타동작
    // Action Action { get; }
    <<<<<<<

HEAD
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
    ====== =
    >>>>>>> 5

    private b6471c(fix #137)
}