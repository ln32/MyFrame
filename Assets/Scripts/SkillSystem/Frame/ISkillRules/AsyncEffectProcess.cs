// 기본 단일 타겟팅

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class AsyncEffectProcess
{
    public static void Process(InstantSkillData data, SkillCasterComponent caster, Vector3 targetPoint, float reachTime)
    {
        if (data.isDot)
        {
            DamageOverTimeEffectProcess(data, caster, targetPoint, reachTime);
        }
        else
        {
            AsyncSingleEffectProcess(data, caster, targetPoint, reachTime);
        }
    }

    private static void AsyncSingleEffectProcess(InstantSkillData data, SkillCasterComponent caster,
        Vector3 targetPoint, float reachTime)
    {
        int effectOnRadiusTargetCount = data.effectOnRadiusTargetCount;

        if (reachTime <= 0)
        {
            return;
        }

        List<Vector3> targetTransform = StageManagerCommand.GetPositionsFromObjects()
            .OrderBy(e => Vector2.Distance(targetPoint, new Vector2(e.x, e.y)))
            .Take(effectOnRadiusTargetCount).ToList();

        for (int i = 0; i < targetTransform.Count; i++)
        {
            Vector3 target = targetTransform[i];
            caster.DelayUnitask.DelayedAction(() =>
            {
                StageManagerCommand.HitPointEvent_ByDistance(caster, target, data);
                NabeDebug.Log($"{caster.Transform.name} is attack {target} with {data.skillName}");
            }, reachTime).Forget();
        }
    }

    private static void DamageOverTimeEffectProcess(InstantSkillData data, SkillCasterComponent caster,
        Vector3 targetPoint, float reachTime)
    {
        int effectOnRadiusTargetCount = data.effectOnRadiusTargetCount;
        int repeatCount = data.repeatCount;
        float timeGap = data.repeatTimeGap;

        if (reachTime <= 0)
        {
            NabeDebug.Log($" ReachTime Error : {caster.Transform.name}");
            return;
        }

        List<Vector3> list = StageManagerCommand.GetPositionsFromObjects()
            .OrderBy(e => Vector2.Distance(targetPoint, new Vector2(e.x, e.y)))
            .Take(effectOnRadiusTargetCount).ToList();

        for (int i = 0; i < list.Count; i++)
        {
            Vector3 target = list[i];
            caster.DelayUnitask.RepeatedAction(
                () =>
                {
                    StageManagerCommand.HitPointEvent_ByDistance(caster, target, data);
                },
                repeatCount,
                timeGap
            );
        }
    }
}