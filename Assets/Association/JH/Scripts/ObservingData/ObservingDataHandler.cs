using System;
using System.Collections.Generic;
using DataSet;
using UnityEngine;

[CreateAssetMenu(fileName = "DataInitializer", menuName = "ScriptableObjects/DataInitializer", order = 1)]
public class ObservingDataHandler : ScriptableObject, iDataHandler, iActionHandler
{
    // 타입별 딕셔너리 1:1대응
    [SerializeField] private Dictionary<Type, iDictionaryProvider> typeDictionaryMap = new();

    public void AddAction<T>(string valueName, Action<T> reactAction, bool updateData = false)
    {
        var target = GetObservingData<T>(valueName);
        target.onChange += reactAction;

        if (updateData)
            reactAction(target.Data);
    }

    public void RemoveAction<T>(string valueName, Action<T> reactAction)
    {
        var target = GetObservingData<T>(valueName);
        target.onChange -= reactAction;
    }

    public void SetValue<T>(string valueName, T value)
    {
        var target = GetObservingData<T>(valueName);
        target.Data = value;
    }

    public T GetValue<T>(string valueName)
    {
        var target = GetObservingData<T>(valueName);
        return target.Data;
    }


    // 위 InitNames 데이터를 생성하는 함수. 아마 데이터 로드할 때 데이터마다 변수명 엮고 생성할 거 같음.

    public void AwakeFunc<T, TEnum>(DataTypePairing<T, TEnum> PairObj) where TEnum : Enum
    {
        List<string> target = PairObj.DataNameList;
        if (!typeDictionaryMap.ContainsKey(typeof(T)))
        {
            typeDictionaryMap[typeof(T)] = new TypeDictionary<T>();
        }

        for (int i = 0; i < target.Count; i++)
        {
            string valueName = target[i];
            typeDictionaryMap[typeof(T)].AddData_withName(valueName);
        }
    }

    public void InitValue<T>(string dataName)
    {
        if (!typeDictionaryMap.ContainsKey(typeof(T)))
        {
            typeDictionaryMap[typeof(T)] = new TypeDictionary<T>();
        }

        string valueName = dataName;
        typeDictionaryMap[typeof(T)].AddData_withName(valueName);
    }

    // 딕셔너리 등록 및 초기화
    private void EnsureDictionaryExists<T>()
    {
        var type = typeof(T);
        if (!typeDictionaryMap.ContainsKey(type))
        {
            typeDictionaryMap[type] = new TypeDictionary<T>();
        }
    }

    private ObservingData<T> GetObservingData<T>(string valueName)
    {
        EnsureDictionaryExists<T>();

        if (typeDictionaryMap[typeof(T)] is TypeDictionary<T> typeDict)
        {
            var data = typeDict.GetData(valueName);
            if (data == null)
                throw new Exception($"Value '{valueName}' of type {typeof(T).Name} not found");

            return data;
        }

        throw new Exception($"Dictionary for type {typeof(T).Name} not found");
    }
}

public interface iDataHandler
{
    void SetValue<T>(string valueName, T value);
    T GetValue<T>(string valueName);
}

public interface iActionHandler
{
    void AddAction<T>(string ValueName, Action<T> reactAction, bool updateData = false);
    void RemoveAction<T>(string ValueName, Action<T> reactAction);
}