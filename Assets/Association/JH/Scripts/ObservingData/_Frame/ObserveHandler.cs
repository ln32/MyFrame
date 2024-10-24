
using System;
using System.Collections.Generic;
using UnityEngine;

public interface iDictionaryProvider
{
    ObservingData<T> GetData<T>(string key);
}

[Serializable]
public class TypeDictionary<T> : iDictionaryProvider
{
    [SerializeField] private List<string> names = new();
    private Dictionary<string, ObservingData<T>> dataDictionary = new();

    public TypeDictionary<T> InitComponent()
    {
        foreach (var item in names)
        {
            if (!dataDictionary.ContainsKey(item))
                dataDictionary[item] = new ObservingData<T>();
        }

        return this;
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
