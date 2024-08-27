using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] internal ProfileData _ProfileData;
    [SerializeField] internal CurrencyData _CurrencyData;

    public IProfileDataHandler GetProfileDataDataHandler()
    {
        return _ProfileData;
    }

    public ICurrencyDataHandler GetCurrencyDataHandler()
    {
        return _CurrencyData;
    }
}
