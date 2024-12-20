using System.Collections.Generic;
using UnityEngine;

public class CastContext
{
    private readonly InstantSkillData _data;

    public CastContext(InstantSkillData data)
    {
        _data = data;
    }

    public void ExecuteTargeting(SkillCasterComponent caster)
    {
        caster.DelayUnitask.RepeatedAction(
            () =>
            {
                ExecuteOnce(caster);
            },
            _data.loopCount,
            _data.loopTimeGap
        ).Forget();
    }

    private void ExecuteOnce(SkillCasterComponent caster)
    {
        List<Vector3> targets =
            GetCastTargetingPointProcess.GetProcess(_data, caster.TargetingRule.GetPositionsFromObjects());

        // TODO : castCount / tick 계산 후 반복
        foreach (Vector3 targetPoint in targets)
        {
            // With Instance Projectile 
            ProjectileToEffectProcess.ProjectileProcess(_data, caster, targetPoint, out float reachTime);
            // 투사체 영향 비동기
            AsyncEffectProcess.Process(_data, caster, targetPoint, reachTime);
        }
    }
}


public enum TargetingCase
{
    First,
    Random,
    RangeEffect
}