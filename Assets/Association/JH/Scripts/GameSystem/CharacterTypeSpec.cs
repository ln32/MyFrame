using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TotalSpec : IBattlePropertyComposition
{
    public SerializedDictionary<string, int> properties { get; set; } = new();
}

public class CharacterTypeSpec : IBattlePropertyComposition
{
    public SerializedDictionary<string, int> properties { get; set; } = new();
}
