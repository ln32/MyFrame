using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EquipItemPlatform : IBattlePropertyComposition
{
    [SerializeField]
    public Dictionary<string, int> properties { get; } = new();

    [SerializeField]
    public Dictionary<EquipPart, Item> equipItems { get; } = new();
}