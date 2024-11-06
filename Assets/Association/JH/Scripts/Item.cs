using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Item : IEquipable
{
    public string Name { get; set; }
    public List<IRule> RestrictionRules { get; } = new();

    public EquipPart EquipPart { get; set; }

    [SerializeField]
    public SerializedDictionary<string, int> properties { get; } = new();

    [SerializeField]
    public SerializedDictionary<string, OptionHistory> history { get; } = new();

  

    public void SetOption(string optionId, string _propName, int _propValue)
    {
        history[optionId] = new() { propName = _propName, propValue = _propValue };

        int cash = 0;
        properties.TryGetValue(_propName, out cash);
        properties[_propName] = cash + _propValue;
    }

    public void RevertOption(string _propName)
    {
        // 있으면 취소 및 적용 if(_propName)
    }
}

public struct OptionHistory
{
    public string propName;
    public int propValue;
}