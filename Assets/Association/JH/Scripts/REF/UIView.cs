using System;
using TMPro;
using UnityEngine;

public class UIView : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    bool isAdded = false;
    private void OnEnable()
    {
        AddEvent();
    }

    private void OnDisable()
    {
        RemoveEvent();
    }


    [ContextMenu("AddEvent")]
    private void AddEvent()
    {
        if (isAdded)
            return;
        DataManager.instance.Currency.AddEvent(CurrencyType_Int.Gold, UpdateHpUI);
        isAdded = true;
    }

    [ContextMenu("RemoveEvent")]
    private void RemoveEvent()
    {
        if (!isAdded)
            return;
        DataManager.instance.Currency.RemoveEvent(CurrencyType_Int.Gold, UpdateHpUI);
        isAdded = false;
    }

    [ContextMenu("ChangeEvent")]
    private void ChangeEvent()
    { 
        int value = DataManager.instance.Currency.Get(CurrencyType_Int.Gold);
        Debug.Log( value + " <<" );
        DataManager.instance.Currency.Set(CurrencyType_Int.Gold, value+1);
    }

    public void UpdateHpUI(int hp)
    {
        textMeshPro.text = hp + "";
    }
}   