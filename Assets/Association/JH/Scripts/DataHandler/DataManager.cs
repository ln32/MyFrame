using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] internal ManagingEnumData_DEBUG<VisualType_String, string> _VisualDataDBG;

    [SerializeField] internal ManagingEnumData_DEBUG<CurrencyType_Int,int> _CurrencyDBG;
    public ManagingEnumData_DEBUG<CurrencyType_Int, int> Currency { get { return _CurrencyDBG; } }
    public ManagingEnumData_DEBUG<VisualType_String, string> VisualData { get { return _VisualDataDBG; } }

}