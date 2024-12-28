using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public static class GetTriggerTargetingProcess
{
    public static List<Vector3> GetTriggerTargetProcess(InstantSkillData data, List<Vector3> enemies,
        HashSet<Vector3> history)
    {
        if (enemies == null || enemies.Count == 0)
        {
            throw new Exception();
        }

        return data.targetingCase switch
        {
            TargetingCase.First => TargetingCase_First(data, enemies, history),
            TargetingCase.Random => TargetingCase_Random(data, enemies, history),
            TargetingCase.RangeEffect => TargetingCase_RangeEffect(data, enemies, history),

            _ => throw new ArgumentOutOfRangeException(nameof(data.targetingCase), "Unsupported targeting case")
        };
    }

    private static List<Vector3> TargetingCase_First(InstantSkillData data, List<Vector3> enemies,
        HashSet<Vector3> history)
    {
        // 지정된 개수만큼 가져오기
        return enemies
            .Where(vector3 => !history.Contains(vector3))
            .Take(data.searchCastTargetCount)
            .ToList();
    }

    private static List<Vector3> TargetingCase_Random(InstantSkillData data, List<Vector3> enemies,
        HashSet<Vector3> history)
    {
        Random random = new();

        // 적 목록을 랜덤하게 셔플하고 지정된 개수만큼 선택
        return enemies
            .Where(vector3 => !history.Contains(vector3))
            .OrderBy(_ => random.NextDouble()) // 무작위 정렬
            .Take(data.searchCastTargetCount) // 최대 개수 제한
            .ToList();
    }

    private static List<Vector3> TargetingCase_RangeEffect(InstantSkillData data, List<Vector3> enemies,
        HashSet<Vector3> history)
    {
        List<Vector3> returnList = new();

        Vector3 averagePoint = Vector3.zero;
        foreach (Vector3 target in enemies)
        {
            averagePoint += target;
        }

        averagePoint /= enemies.Count;
        returnList.Add(averagePoint);

        return returnList;
    }
}