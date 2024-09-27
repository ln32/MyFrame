using DataSet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_Test : MonoBehaviour
{
    public DataEnum index = DataEnum.GoldCoin;

    [ContextMenu("GoldCoin ++")]
    public void Func_1()
    {
        DataManager.instance.DataEnum.SetDelta(DataEnum.GoldCoin, 1);
    }

    [ContextMenu("index += GoldCoin")]
    public void Func_2()
    {
        DataManager.instance.DataEnum.SetDelta(index, DataManager.instance.DataEnum.Get(DataEnum.GoldCoin));
    }
}
