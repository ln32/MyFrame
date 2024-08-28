using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] internal CurrencyData _Currency;

    public CurrencyData Currency { get { return _Currency; } }
}
