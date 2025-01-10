using System;
using DataSet;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [SerializeField] private ObservingDataHandler data;
    [SerializeField] public DataTypePairing<int, CurrencyData> INT_Currency = new();
    [SerializeField] public DataTypePairing<string, UserProfileData> STRING_UserProfile = new();

    // 다른 타입 observing 필요 시  DataTypePairing<Type, UserProfileData> 선언 및 data.AwakeFunc 하면 됩니다.


    private void Awake()
    {
        data.AwakeFunc(INT_Currency);
        data.AwakeFunc(STRING_UserProfile);
    }

    public void AddValue(string _name)
    {
        data.InitValue<int>(_name);
    }

    public void AddAction<T>(string valueName, Action<T> action, bool updateData = false)
    {
        data.AddAction(valueName, action, updateData);
    }

    public void RemoveAction<T>(string valueName, Action<T> action)
    {
        data.RemoveAction(valueName, action);
    }

    public void SetValue<T>(string valueName, T value)
    {
        data.SetValue(valueName, value);
    }

    public void SetDelta<T>(string valueName, T value)
    {
        var isParsed = false;
        do
        {
            if (value is int intValue)
            {
                var cash = GetValue<int>(valueName);
                SetValue(valueName, cash + intValue);
                isParsed = true;
                break;
            }

            if (value is float floatValue)
            {
                var cash = GetValue<float>(valueName);
                SetValue(valueName, cash + floatValue);
                isParsed = true;
                break;
            }

            if (value is double doubleValue)
            {
                var cash = GetValue<double>(valueName);
                SetValue(valueName, cash + doubleValue);
                isParsed = true;
                break;
            }

            if (value is long longValue)
            {
                var cash = GetValue<long>(valueName);
                SetValue(valueName, cash + longValue);
                isParsed = true;
                break;
            }

            if (value is string stringValue)
            {
                var cash = GetValue<string>(valueName);
                SetValue(valueName, cash + stringValue);
                isParsed = true;
                break;
            }
        } while (false);

        if (!isParsed)
            throw new ArgumentException("Wrong SetDelta Case - " + typeof(T).Name);
    }

    public T GetValue<T>(string valueName)
    {
        return data.GetValue<T>(valueName);
    }
}