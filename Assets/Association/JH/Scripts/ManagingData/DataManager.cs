using DataSet;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] internal ManagingCurrencyInt _CurrencyDBG = new();
    [SerializeField] internal ManagingVisualTypeString _VisualDataDBG = new();

    public ManagingCurrencyInt Currency { get { return _CurrencyDBG; } }
    public ManagingVisualTypeString VisualData { get { return _VisualDataDBG; } }
}