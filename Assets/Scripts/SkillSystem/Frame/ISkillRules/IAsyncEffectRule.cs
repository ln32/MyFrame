// 기본 단일 타겟팅

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class BranchEffectRule
{
    // TODO : Get Target Method
    public static IAsyncEffectRule Get(DefaultSkillFrame data)
    {
        return new DefaultAsyncEffectRule(data);
    }
}

public class DefaultAsyncEffectRule : IAsyncEffectRule
{
    private readonly int _effectOnRadiusTargetCount;
    private readonly DefaultSkillFrame _skill;


    public DefaultAsyncEffectRule(DefaultSkillFrame skill)
    {
        _skill = skill;
        _effectOnRadiusTargetCount = skill.EffectOnRadiusTargetCount;
    }

    public void DelayedEffect(SkillCasterComponent caster, Vector3 targetPoint, float reachTime)
    {
        if (reachTime <= 0)
        {
            return;
        }

        List<Vector3> targetTransform = StageManagerCommunicate.GetPositionsFromObjects()
            .OrderBy(e => Vector2.Distance(targetPoint, new Vector2(e.x, e.y)))
            .Take(_effectOnRadiusTargetCount).ToList();

        for (int i = 0; i < targetTransform.Count; i++)
        {
            Vector3 target = targetTransform[i];
            caster.DelayUnitask.DelayedAction(() =>
            {
                StageManagerCommunicate.HitPointEvent_ByDistance(caster, target, _skill);
                NabeDebug.Log($"{caster.Transform.name} is attack {target} with {_skill.SkillName}");
            }, reachTime).Forget();
        }
    }
}


public class DamageOverTimeEffectRule : IAsyncEffectRule
{
    private readonly int _effectOnRadiusTargetCount;
    private readonly int _repeatCount;
    private readonly DefaultSkillFrame _skill;
    private readonly float _timeGap;


    public DamageOverTimeEffectRule(DefaultSkillFrame skill)
    {
        _skill = skill;
        _timeGap = skill.TimeGap;
        _repeatCount = skill.RepeatCount;
        _effectOnRadiusTargetCount = skill.EffectOnRadiusTargetCount;
    }

    public void DelayedEffect(SkillCasterComponent caster, Vector3 targetPoint, float reachTime)
    {
        if (reachTime <= 0)
        {
            NabeDebug.Log($" ReachTime Error : {caster.Transform.name}");
            return;
        }

        List<Vector3> list = StageManagerCommunicate.GetPositionsFromObjects()
            .OrderBy(e => Vector2.Distance(targetPoint, new Vector2(e.x, e.y)))
            .Take(_effectOnRadiusTargetCount).ToList();

        for (int i = 0; i < list.Count; i++)
        {
            Vector3 target = list[i];
            caster.DelayUnitask.RepeatedAction(
                () =>
                {
                    StageManagerCommunicate.HitPointEvent_ByDistance(caster, target, _skill);
                    NabeDebug.Log($"{caster.Transform.name} is attack {target} with {_skill.SkillName}");
                },
                _repeatCount,
                _timeGap
            );
        }
    }
}