using System.Collections.Generic;
using UnityEngine;

// 타겟팅 규칙 인터페이스
public interface IGetTargetingRule
{
    List<Vector3> GetTargets(List<Vector3> enemies);
}

// 타겟팅 규칙 인터페이스
public interface IProjectileRule
{
    Vector3 CastPoint { get; }
    Vector3 TargetPoint { get; }
    void GetTimeOnEffect(SkillCasterComponent caster, Vector3 targetPoint, out float reachTime);
}

// 타겟팅 규칙 인터페이스
public interface IAsyncEffectRule
{
    void DelayedEffect(SkillCasterComponent caster, Vector3 targetPoint, float reachTime);
}

public class CastContext
{
    private readonly int _repeatCastingCount;
    private readonly float _repeatCastTimeGap;
    internal readonly IAsyncEffectRule AsyncEffectRule;
    internal readonly IGetTargetingRule GetTargetingRule;
    internal readonly IProjectileRule ProjectileRule;

    public CastContext(DefaultSkillFrame skill)
    {
        GetTargetingRule = BranchTargetingRule.Create(skill);
        ProjectileRule = new ProjectileSkillRule(skill);
        AsyncEffectRule = new DefaultAsyncEffectRule(skill);
        _repeatCastingCount = skill.RepeatCount;
        _repeatCastTimeGap = skill.TimeGap;
    }

    public void ExecuteTargeting(SkillCasterComponent caster)
    {
        caster.DelayUnitask.RepeatedAction(
            () =>
            {
                ExecuteOnce(caster);
            },
            _repeatCastingCount,
            _repeatCastTimeGap
        );
    }


    private void ExecuteOnce(SkillCasterComponent caster)
    {
        List<Vector3> targets = GetTargetingRule.GetTargets(StageManagerCommunicate.GetPositionsFromObjects());

        // TODO : castCount / tick 계산 후 반복
        foreach (Vector3 targetPoint in targets)
        {
            // With Instance Projectile 
            ProjectileRule.GetTimeOnEffect(caster, targetPoint, out float reachTime);
            // 투사체 영향 비동기
            AsyncEffectRule.DelayedEffect(caster, targetPoint, reachTime);
        }
    }
}


public enum TargetingCase
{
    First,
    Random
}