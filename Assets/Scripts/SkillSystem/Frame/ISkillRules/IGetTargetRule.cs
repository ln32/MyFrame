using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

// 기본 멀티 타겟팅
public static class BranchTargetingRule
{
    // TODO : Get Target Method
    public static IGetTargetingRule Create(DefaultSkillFrame data)
    {
        return data.TargetingCase switch
        {
            TargetingCase.First => new FirstTargetingRule(data.SearchCastTargetCount),
            TargetingCase.Random => new RandomMultiTargetingRule(data.SearchCastTargetCount),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}

// 기본 멀티 타겟팅
public class FirstTargetingRule : IGetTargetingRule
{
    private readonly int _searchTargetCount;

    // TODO : Get Target Method
    public FirstTargetingRule(int searchTargetCount)
    {
        _searchTargetCount = searchTargetCount;
    }

    public List<Vector3> GetTargets(List<Vector3> enemies)
    {
        return enemies.Take(_searchTargetCount).ToList();
    }
}

// 랜덤 타겟팅 규칙
public class RandomMultiTargetingRule : IGetTargetingRule
{
    private readonly Random _random;
    private readonly int _searchTargetCount;

    public RandomMultiTargetingRule(int searchTargetCount)
    {
        _searchTargetCount = searchTargetCount;
        _random = new Random();
    }

    public List<Vector3> GetTargets(List<Vector3> enemies)
    {
        if (enemies.Count == 0)
        {
            return new List<Vector3>();
        }

        List<Vector3> shuffledEnemies = enemies
            .OrderBy(e => _random.NextDouble()) // 랜덤 정렬
            .Take(_searchTargetCount) // maxCount 개수만큼 선택
            .ToList();
        return shuffledEnemies;
    }
}