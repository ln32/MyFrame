using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AchievementSpec : IBattlePropertyComposition
{
    public Dictionary<string, int> properties { get; set; } = new();
}

public class CharacterTypeSpec : IBattlePropertyComposition
{
    public Dictionary<string, int> properties { get; set; } = new();
}
