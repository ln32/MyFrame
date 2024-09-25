using DataSet;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] internal ManagingCurrencyInt _CurrencyDBG = new();
    [SerializeField] internal ManagingVisualTypeString _VisualDataDBG = new();
    [SerializeField] internal ManagingReturnEnumInt _ManagingReturnEnumInt = new();

    public IManagingDataHandler<DefaultCurrency,int> Currency { get { return _CurrencyDBG; } }
    public IManagingDataHandler<VisualType, string> VisualData { get { return _VisualDataDBG; } }
    public IManagingDataHandler<TestEnum, int> TestEnum { get { return _ManagingReturnEnumInt; } }
}