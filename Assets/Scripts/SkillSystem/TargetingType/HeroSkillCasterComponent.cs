using Battle;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeroSkillCasterComponent : ITargetingRule
{
    public List<Vector3> GetPositionsFromObjects()
    {
        IList<GameObject> objects = StageManager.Instance.SpawnedMonsterList;
        List<Vector3> positions = new();

        foreach (GameObject obj in objects)
        {
            if (obj != null) // 널 체크
            {
                positions.Add(obj.transform.position); // Transform에서 Position 추출
            }
        }

        return positions;
    }

    public bool HitPointEvent_ByDistance(Vector3 point, InstantSkillData data)
    {
        int effectTargetPerCast = data.effectTargetPerCast;
        float effectRadius = data.effectRadius;

        IList<GameObject> objects = StageManager.Instance.SpawnedMonsterList;

        // 객체의 거리 계산 및 정렬
        var sortedObjects = objects
            .Where(obj => obj != null && obj.transform != null)
            .Select(obj => new { GameObject = obj, Distance = Vector3.Distance(obj.transform.position, point) })
            .Where(item => item.Distance <= effectRadius) // 반경 안의 객체만 필터링
            .OrderBy(item => item.Distance) // 거리 기준으로 정렬
            .ToList();

        bool hitOccured = false;

        // 정렬된 객체 순서대로 처리
        foreach (var item in sortedObjects)
        {
            item.GameObject.GetComponent<Damageable>().OnDamaged();
            effectTargetPerCast--;
            hitOccured = true;

            if (effectTargetPerCast <= 0)
            {
                break;
            }
        }

        return hitOccured;
    }
}