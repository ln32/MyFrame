using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

// 기본 멀티 타겟팅
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
        // 스킬 데이터
        int searchCastTargetCount = data.searchCastTargetCount; // 최대 타겟 수
        float effectRadius = data.effectRadius; // 스킬 효과 반지름
        Random random = new();

        // 리턴할 리스트와 필요한 변수들 선언
        List<Vector3> targetEnemies = new();
        List<Vector3> returnList = new();

        // 반복 처리
        while (enemies.Count > 0 && returnList.Count < searchCastTargetCount)
        {
            // 1. 랜덤 오브젝트를 뽑고 main target으로 설정
            int randomIndex = random.Next(0, enemies.Count);
            Vector3 mainTarget = enemies[randomIndex];
            enemies.RemoveAt(randomIndex);
            targetEnemies.Add(mainTarget);

            // 2. main target과 effectRadius 이내의 오브젝트를 찾음
            List<Vector3> closeEnemies = new();
            foreach (Vector3 enemy in enemies)
            {
                if (Vector3.Distance(mainTarget, enemy) <= effectRadius)
                {
                    closeEnemies.Add(enemy);
                }
            }

            // 3. 가까운 오브젝트를 제외 후 targetEnemies에 추가
            foreach (Vector3 closeEnemy in closeEnemies)
            {
                enemies.Remove(closeEnemy);
                targetEnemies.Add(closeEnemy);
            }

            // 4. targetEnemies의 평균값 계산 후 returnList에 추가
            Vector3 averagePoint = Vector3.zero;
            foreach (Vector3 target in targetEnemies)
            {
                averagePoint += target;
            }

            averagePoint /= targetEnemies.Count;
            returnList.Add(averagePoint);
        }

        return returnList;
    }
}