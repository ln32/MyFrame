using DataSet;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyData : MonoBehaviour ,ICurrencyDataHandler
{
    private Dictionary<CurrencyType, ManangingData<int>> _currencies = null;

    public CurrencyData()
    {
        _currencies = new Dictionary<CurrencyType, ManangingData<int>>();

        foreach (CurrencyType type in Enum.GetValues(typeof(CurrencyType)))
        {
            _currencies[type] = new ManangingData<int>();
        }
    }

    public int Get(CurrencyType type)
    {
        return _currencies[type].Data;
    }

    public void Set(CurrencyType type, int value)
    {
        _currencies[type].Data = value;
    }
}
