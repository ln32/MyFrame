using System;
using SkillAffactCase;
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

    // TODO : 공격 추가 액션
    // public Action<IDefender> DamagingAction { get; set; }

    void CastAttack();
}

public interface IDefender : IBattleRole
{
    // 기타동작
    // Action Action { get; }
}