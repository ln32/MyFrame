using UnityEngine;
using UnityEngine.Rendering;

public class BattlePropertyComposition : MonoBehaviour
{
    [SerializeField]
    private SerializedDictionary<string, int> properties = new SerializedDictionary<string, int>();

    public int GetProperty<T>() where T : BattleProperty
    {
        string propName = typeof(T).Name;

        return properties.TryGetValue(propName, out var value) ? value : 0;
    }
    public void SetProperty<T>(int inputValue) where T : BattleProperty
    {
        string propName = typeof(T).Name;

        properties[propName] = inputValue;
    }

    public void RemoveProperty<T>() where T : BattleProperty
    {
        string propName = typeof(T).Name;

        properties.Remove(propName);
    }

    public void SetDelta<T>(int propValue) where T : BattleProperty
    {
        string propName = typeof(T).Name;

        int cash = properties.TryGetValue(propName, out var value) ? value : -1;
        if (cash == -1)
        {
            properties[propName] = propValue;
        }
        else
        {
            properties[propName] = cash + propValue;
        }
    }




    public int GetProperty(string propName)
    {
        return properties.TryGetValue(propName, out var value) ? value : 0;
    }
    public void SetProperty(string propName, int propValue)
    {
        properties[propName] = propValue;
    }
    public void RemoveProperty(string propName)
    {
        properties.Remove(propName);
    }
    public void SetDelta(string propName, int propValue)
    {
        int cash = properties.TryGetValue(propName, out var value) ? value : -1;
        if (cash == -1)
        {
            properties[propName] = propValue;
        }
        else
        {
            properties[propName] = cash + propValue;
        }
    }

}
