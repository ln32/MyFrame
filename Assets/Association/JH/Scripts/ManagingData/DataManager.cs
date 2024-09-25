using DataSet;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] internal Managing_Currency_Int _CurrencyDBG = new();
    [SerializeField] internal Managing_VisualType_String _VisualDataDBG = new();
    [SerializeField] internal Managing_TestEnum_Int _ManagingReturnEnumInt = new();

    public IManagingDataHandler<Currency_Old,int> Currency { get { return _CurrencyDBG; } }
    public IManagingDataHandler<VisualType_Old, string> VisualData { get { return _VisualDataDBG; } }
    public IManagingDataHandler<TestEnum, int> TestEnum { get { return _ManagingReturnEnumInt; } }
}
