using DataSet;
using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] private ObservingDataHandler data;
    [SerializeField] public DataTypePairing<int, CurrencyData> INT_Currency = new();
    [SerializeField] public DataTypePairing<string, UserProfileData> STRING_UserProfile = new();

    // 다른 타입 observing 필요 시  DataTypePairing<Type, UserProfileData> 선언 및 data.AwakeFunc 하면 됩니다.


    private void Awake()
    {
        data.AwakeFunc(INT_Currency);
        data.AwakeFunc(STRING_UserProfile);
    }

    public void AddAction<T>(string valueName, Action<T> action, bool updateData = false)
    => data.AddAction(valueName, action, updateData);

    public void RemoveAction<T>(string valueName, Action<T> action)
        => data.RemoveAction(valueName, action);

    public void SetValue<T>(string valueName, T value)
        => data.SetValue(valueName, value);

    public void SetDelta<T>(string valueName, T value)
    {
        try
        {
            bool isParsed = false;
            do
            {
                if (value is int intValue)
                {
                    int cash = GetValue<int>(valueName);
                    SetValue<int>(valueName, cash + intValue);
                    isParsed = true;
                    break;
                }
                if (value is float floatValue)
                {
                    float cash = GetValue<float>(valueName);
                    SetValue<float>(valueName, cash + floatValue);
                    isParsed = true;
                    break;
                }
                if (value is double doubleValue)
                {
                    double cash = GetValue<double>(valueName);
                    SetValue<double>(valueName, cash + doubleValue);
                    isParsed = true;
                    break;
                }
                if (value is long longValue)
                {
                    long cash = GetValue<long>(valueName);
                    SetValue<long>(valueName, cash + longValue);
                    isParsed = true;
                    break;
                }
                if (value is string stringValue)
                {
                    string cash = GetValue<string>(valueName);
                    SetValue<string>(valueName, cash + stringValue);
                    isParsed = true;
                    break;
                }
            } while (false);

            if (!isParsed)
                throw new ArgumentException("Wrong SetDelta Case - " + typeof(T).Name);

        }
        catch (Exception)
        {

            throw;
        }
    }

    public T GetValue<T>(string valueName)
    { return data.GetValue<T>(valueName); }
}
