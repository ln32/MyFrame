using DataSet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_Test : MonoBehaviour
{
    [ContextMenu("Func_1")]
    public void Func_1()
    {
        DataManager.instance.Currency.SetDelta(Currency_Old.GoldCoin, 1);
    }

    [ContextMenu("Func_2")]
    public void Func_2()
    {
        DataManager.instance.Currency.SetDelta(Currency_Old.DiamondCoin, 2);
    }
}
