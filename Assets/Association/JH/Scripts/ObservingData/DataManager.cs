using DataSet;
using System;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] private ObservingDataHandler data;
    [SerializeField] public DataTypePairing<int, CurrencyData> Currency = new();
    [SerializeField] public DataTypePairing<string, UserProfileData> UserProfile = new();

    private void Awake()
    {
        data.AwakeFunc(Currency);
        data.AwakeFunc(UserProfile);
    }

    public void AddAction<T>(string valueName, Action<T> action, bool updateData = false)
    => data.AddAction(valueName, action, updateData);

    public void RemoveAction<T>(string valueName, Action<T> action)
        => data.RemoveAction(valueName, action);

    public void SetValue<T>(string valueName, T value)
        => data.SetValue(valueName, value);
    public T GetValue<T>(string valueName)
    { return data.GetValue<T>(valueName); }
}
