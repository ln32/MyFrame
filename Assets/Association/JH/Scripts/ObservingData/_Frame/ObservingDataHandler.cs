using System;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "DataInitializer", menuName = "ScriptableObjects/DataInitializer", order = 1)]

public class ObservingDataHandler : ScriptableObject, iDataHandler, iActionHandler
{
    [SerializeField] TypeDictionary<string> values_string= new();
    [SerializeField] TypeDictionary<int> values_int= new();
    [SerializeField] TypeDictionary<float> values_float = new();
    [SerializeField] TypeDictionary<Sprite> values_Sprite = new();

    [Space(10)]
    List<iDictionaryProvider> list = new List<iDictionaryProvider>();

    void Awake()
    {
        list.Clear();
        list.Add(values_string.InitComponent());
        list.Add(values_int.InitComponent());
        list.Add(values_float.InitComponent());
        list.Add(values_Sprite.InitComponent());
    }

    ObservingData<T> getObservingData<T>(string valueName)
    {
        try
        {
            ObservingData<T> target = null;
            foreach (var item in list)
            {
                if (item.GetData<T>(valueName) != null)
                {
                    target = item.GetData<T>(valueName);
                    break;
                }
            }

            if (target == null)
                throw new Exception("Null Execption");

            return target;
        }
        catch (Exception e)
        {
            Debug.Log(valueName + "(" + typeof(T).Name + ") - " + e);
            throw;
        }

    }

    public void SetValue<T>(string valueName, T value)
    {
        ObservingData<T> target = getObservingData<T>(valueName);
        target.Data = value;
    }

    public T GetValue<T>(string valueName)
    {
        ObservingData<T> target = getObservingData<T>(valueName);
        return target.Data;
    }

    public void AddAction<T>(string valueName, Action<T> reactAction, bool updateData = false)
    {
        ObservingData<T> target = getObservingData<T>(valueName);
        target.onChange += reactAction;

        if (updateData)
            reactAction(target.Data);
    }

    public void RemoveAction<T>(string valueName, Action<T> reactAction)
    {
        ObservingData<T> target = getObservingData<T>(valueName);
        target.onChange -= reactAction;
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
