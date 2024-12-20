using Battle;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSkillCasterComponent : ITargetingRule
{
    public List<Vector3> GetPositionsFromObjects()
    {
        List<Vector3> positions = new();
        positions.Add(StageManager.Instance.MainCharacter.transform.position);
        return positions;
    }

    public bool HitPointEvent_ByDistance(Vector3 point, InstantSkillData data)
    {
        Transform hero = StageManager.Instance.MainCharacter.transform;

        if (Vector3.Distance(hero.position, point) > data.effectRadius)
        {
            return false;
        }

        hero.GetComponent<Damageable>().OnDamaged();
        return true;
    }
}