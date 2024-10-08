using DataSet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_Test : MonoBehaviour
{
    public DataEnum index = DataEnum.GoldCoin;
    public float value = 1;
    public Sprite _sprite;

    [ContextMenu("+= value")]
    public void Func_1()
    {
        int cash = DataManager.instance.DataEnum.Get(index);
        DataManager.instance.DataEnum.Set(index, (int)(cash + value));
        SetSprite();
    }

    [ContextMenu("*= value")]
    public void Func_2()
    {
        int cash = DataManager.instance.DataEnum.Get(index);
        DataManager.instance.DataEnum.Set(index, (int)(cash * value));
        SetSprite();
    }

    [ContextMenu("SetSprite")]
    public void SetSprite()
    {
        //Debug.Log(GradeSelector.GetRandomIndex_Sample() + " <<");
    }
}
