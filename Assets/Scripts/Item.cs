using System.Collections.Generic;

public class Item : IEquipable
{
    public Dictionary<string, OptionHistory> history { get; } = new();

    public string Name { get; set; }
    public List<IRule> RestrictionRules { get; } = new();

    public EquipPart EquipPart { get; set; }

    public Dictionary<string, int> properties { get; } = new();


    public void SetOption(string optionId, string _propName, int _propValue)
    {
        history[optionId] = new OptionHistory { propName = _propName, propValue = _propValue };

        var cash = 0;
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