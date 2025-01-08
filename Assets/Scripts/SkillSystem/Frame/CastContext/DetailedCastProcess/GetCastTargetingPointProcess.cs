using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public static class GetCastTargetingPointProcess
{
    public static List<Vector3> GetProcess(InstantSkillData data, List<Vector3> enemies)
    {
        if (enemies == null || enemies.Count == 0)
        {
            throw new Exception();
        }

        return data.targetingCase switch
        {
            TargetingCase.First => FirstTargetingProcess(data, enemies),
            TargetingCase.Random => RandomMultiTargetingProcess(data, enemies),
            TargetingCase.RangeEffect => RangeSkillTargetingProcess(data, enemies),

            _ => throw new ArgumentOutOfRangeException(nameof(data.targetingCase), "Unsupported targeting case")
        };
    }

    private static List<Vector3> FirstTargetingProcess(InstantSkillData data, List<Vector3> enemies)
    {
        // 지정된 개수만큼 가져오기
        return enemies.Take(data.searchCastTargetCount).ToList();
    }

    private static List<Vector3> RandomMultiTargetingProcess(InstantSkillData data, List<Vector3> enemies)
    {
        Random random = new();

        // 적 목록을 랜덤하게 셔플하고 지정된 개수만큼 선택
        return enemies
            .OrderBy(_ => random.NextDouble()) // 무작위 정렬
            .Take(data.searchCastTargetCount) // 최대 개수 제한
            .ToList();
    }

    private static List<Vector3> RangeSkillTargetingProcess(InstantSkillData data, List<Vector3> enemies)
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