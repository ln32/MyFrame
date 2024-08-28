using DataSet;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyData : MonoBehaviour ,ICurrencyDataHandler
{
    private Dictionary<CurrencyType_Int, ManangingData<int>> DataSet = null;

    public CurrencyData()
    {
        DataSet = new Dictionary<CurrencyType_Int, ManangingData<int>>();

        foreach (CurrencyType_Int type in Enum.GetValues(typeof(CurrencyType_Int)))
        {
            DataSet[type] = new ManangingData<int>();
        }
    }

    public void AddEvent(CurrencyType_Int type, Action<int> interactFunc)
    {
        DataSet[type].onChange += interactFunc;
    }

    public void RemoveEvent(CurrencyType_Int type, Action<int> interactFunc)
    {
        DataSet[type].onChange -= interactFunc;
    }

    public int Get(CurrencyType_Int type)
    {
        return DataSet[type].Data;
    }


    public void Set(CurrencyType_Int type, int value)
    {
        DataSet[type].Data = value;
    }

}
