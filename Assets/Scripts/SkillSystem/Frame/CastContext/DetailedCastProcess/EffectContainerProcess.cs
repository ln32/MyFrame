// 기본 단일 타겟팅

using UnityEngine;

public static class EffectContainerProcess
{
    public static void Process(InstantSkillData data, SkillCasterComponent caster, Vector3 targetPoint,
        float reachTime = 0)
    {
        if (data.isDot == false)
        {
            AsyncSingleEffectProcess(data, caster, targetPoint, reachTime);
        }
        else
        {
            DamageOverTimeEffectProcess(data, caster, targetPoint, reachTime);
        }
    }


    private static void AsyncSingleEffectProcess(InstantSkillData data, SkillCasterComponent caster,
        Vector3 targetPoint, float reachTime)
    {
        if (reachTime < 0)
        {
            return;
        }

        caster.DelayUnitask.DelayedAction(() =>
        {
            // try & bool
            if (caster.TargetingRule.HitPointEvent_ByDistance(targetPoint, data))
            {
                NabeDebug.Log($"{caster.transform.name} is attack {targetPoint} with {data.skillName}");
            }
        }, reachTime).Forget();
    }


    private static void DamageOverTimeEffectProcess(InstantSkillData data, SkillCasterComponent caster,
        Vector3 targetPoint, float reachTime)
    {
        int tickCount = data.tickCount;
        float timeGap = data.tickRate;

        if (reachTime <= 0)
        {
            NabeDebug.Log($" ReachTime Error : {caster.transform.name}");
            return;
        }

        caster.DelayUnitask.DelayedAction(() =>
        {
            NabeDebug.Log($"{caster.transform.name} is attack {targetPoint} with {data.skillName}");
            caster.DelayUnitask.RepeatedAction(
                () => { caster.TargetingRule.HitPointEvent_ByDistance(targetPoint, data); },
                tickCount,
                timeGap
            ).Forget();
        }, reachTime).Forget();
    }
}