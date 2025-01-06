
using System;
using System.Collections.Generic;
using UnityEngine;

public interface iDictionaryProvider
{
    void AddData_withName(string name);
    ObservingData<T> GetData<T>(string key);
}

[Serializable]
public class TypeDictionary<T> : iDictionaryProvider
{
    private Dictionary<string, ObservingData<T>> dataDictionary = new();

    public void AddData_withName(string name)
    {
        if (!dataDictionary.ContainsKey(name))
        {
            dataDictionary[name] = new ObservingData<T>();
        }
    }

    public ObservingData<T> GetData<T>(string key)
    {
        if (dataDictionary.TryGetValue(key, out var data))
        {
            if (data is ObservingData<T> typedData)
            {
                return typedData;
            }
            else
            {
                Debug.LogError($"Invalid type cast for key: {key}");
            }
        }

        return null;
    }
}
