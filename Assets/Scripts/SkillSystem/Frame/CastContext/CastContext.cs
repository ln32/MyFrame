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
                ExecuteOnceSync(caster);
            },
            _data.loopCount,
            _data.loopTimeGap
        ).Forget();
    }

    private void ExecuteOnceSync(SkillCasterComponent caster)
    {
        List<Vector3> targets =
            GetCastTargetingPointProcess.GetProcess(_data, caster.TargetingRule.GetPositionsFromObjects());

        // TODO : castCount / tick 계산 후 반복
        foreach (Vector3 targetPoint in targets)
        {
            // With Instance Projectile 
            ProjectileToEffectProcess.ProjectileProcess(_data, caster, targetPoint,
                point => EffectContainerProcess.Process(_data, caster, point)
            );
        }
    }
}

public enum TargetingCase
{
    First,
    Random,
    RangeEffect
}