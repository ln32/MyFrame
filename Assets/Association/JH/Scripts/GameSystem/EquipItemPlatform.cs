using UnityEngine;
using UnityEngine.Rendering;

public class EquipItemPlatform : IBattlePropertyComposition
{
    [SerializeField]
    public SerializedDictionary<string, int> properties { get; } = new();

    [SerializeField]
    public SerializedDictionary<EquipPart, Item> equipItems { get; } = new();
}