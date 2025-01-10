using System.Collections.Generic;

public class AchievementSpec : IBattlePropertyComposition
{
    public Dictionary<string, int> properties { get; set; } = new();
}

public class CharacterTypeSpec : IBattlePropertyComposition
{
    public Dictionary<string, int> properties { get; set; } = new();
}