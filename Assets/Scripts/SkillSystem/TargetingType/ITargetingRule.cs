using System;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetingRule
{
    public List<Vector3> GetPositionsFromObjects();
    public bool HitPointEvent_ByDistance(Vector3 point, InstantSkillData data);

    public static ITargetingRule Get(TeamType pool)
    {
        return pool switch
        {
            TeamType.Hero => new HeroSkillCasterComponent(),
            TeamType.Monster => new MonsterSkillCasterComponent(),
            _ => throw new ArgumentOutOfRangeException(nameof(pool), pool, null)
        };
    }
}

public enum TeamType
{
    Hero,
    Monster
}