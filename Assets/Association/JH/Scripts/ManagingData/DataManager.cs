using DataSet;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] internal Managing_PlayerGrowth_Int _PlayerGrowth = new();
    [SerializeField] internal Managing_VisualType_String _VisualDataDBG = new();
    [SerializeField] internal Managing_DataEnum_Int _ManagingReturnEnumInt = new();
    [SerializeField] internal ProfileData _ProfileData = new();


    public iManagingDataHandler<PlayerGrowth, int> PlayerGrowth { get { return _PlayerGrowth; } }
    public iManagingDataHandler<VisualType, string> VisualData { get { return _VisualDataDBG; } }
    public iManagingDataHandler<DataEnum, int> DataEnum { get { return _ManagingReturnEnumInt; } }
}
