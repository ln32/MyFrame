using System;
using System.Collections.Generic;
using UnityEngine;

// 제네릭 인터페이스로 확장
public interface iDictionaryProvider
{
    void AddData_withName(string name);
    object GetObject(string key); // 반환 타입을 object로 설정
}

// 구체적인 타입을 다루는 제네릭 클래스
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
        else
        {
            Debug.LogWarning($"Key '{name}' already exists.");
        }
    }

    public object GetObject(string key)
    {
        if (dataDictionary.TryGetValue(key, out var data))
        {
            return data; // 반환 타입이 object이므로 사용 시 형변환 필요
        }

        Debug.LogError($"Key '{key}' not found.");
        return null;
    }

    public ObservingData<T> GetData(string key)
    {
        var returnData = GetObject(key) as ObservingData<T>;
        return returnData;
    }
}