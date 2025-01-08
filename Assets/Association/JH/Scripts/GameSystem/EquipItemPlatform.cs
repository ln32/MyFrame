using System.Collections.Generic;

public class EquipItemPlatform : IBattlePropertyComposition
{
    public Dictionary<EquipPart, Item> equipItems { get; } = new();
    public Dictionary<string, int> properties { get; } = new();
}