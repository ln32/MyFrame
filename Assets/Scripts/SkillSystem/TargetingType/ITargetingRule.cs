using System;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetingRule
{
    public List<Vector3> GetPositionsFromObjects();
    public bool HitPointEvent_ByDistance(Vector3 point, InstantSkillData data);

    public static ITargetingRule Get(ITargetingPool pool)
    {
        return pool switch
        {
            ITargetingPool.Hero => new HeroSkillCasterComponent(),
            ITargetingPool.Monster => new MonsterSkillCasterComponent(),
            _ => throw new ArgumentOutOfRangeException(nameof(pool), pool, null)
        };
    }
}

public enum ITargetingPool
{
    Hero,
    Monster
}