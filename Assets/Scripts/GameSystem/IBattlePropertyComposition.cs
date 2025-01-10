using System.Collections.Generic;

public interface IBattlePropertyComposition
{
    public Dictionary<string, int> properties { get; }

    public int GetProperty<T>() where T : BattleProperty
    {
        var propName = typeof(T).Name;
        return GetProperty(propName);
    }

    public void SetProperty<T>(int inputValue) where T : BattleProperty
    {
        var propName = typeof(T).Name;
        properties[propName] = inputValue;
    }

    public void RemoveProperty<T>() where T : BattleProperty
    {
        var propName = typeof(T).Name;
        properties.Remove(propName);
    }

    public void SetDelta<T>(int propValue) where T : BattleProperty
    {
        var propName = typeof(T).Name;
        SetDelta(propName, propValue);
    }

    public virtual int GetProperty(string propName)
    {
        return properties.TryGetValue(propName, out var value) ? value : 0;
    }

    public virtual void SetProperty(string propName, int propValue)
    {
        properties[propName] = propValue;
    }

    public virtual void RemoveProperty(string propName)
    {
        properties.Remove(propName);
    }

    public virtual void SetDelta(string propName, int propValue)
    {
        var cash = properties.TryGetValue(propName, out var value) ? value : -1;
        if (cash == -1)
            properties[propName] = propValue;
        else
            properties[propName] = cash + propValue;
    }
}