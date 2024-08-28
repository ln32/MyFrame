using System;
using TMPro;
using UnityEngine;

public class ObservingGUI : MonoBehaviour
{
    public TextMeshProUGUI fixedTMP;
    public TextMeshProUGUI valueTMP;
    public CurrencyType_Int myType = CurrencyType_Int.Gold;
    bool isAdded = false;

    private void OnEnable()
    {
        AddEvent();
    }

    private void OnDisable()
    {
        RemoveEvent();
    }

    private void AddEvent()
    {
        if (isAdded)
            return;
        DataManager.instance.Currency.AddEvent(myType, UpdateMyUI);
        isAdded = true;
    }

    private void RemoveEvent()
    {
        if (!isAdded)
            return; 
        if (!DataManager.instance)
            return;

        DataManager.instance.Currency.RemoveEvent(myType, UpdateMyUI);
        isAdded = false;
    }

    public void UpdateMyUI(int hp)
    {
        valueTMP.text = hp + "";
        valueTMP.ForceMeshUpdate();
    }

    public void SetType(CurrencyType_Int _type)
    {
        transform.name = _type.ToString();
        fixedTMP.text = _type.ToString() + " : ";
        UpdateMyUI(DataManager.instance.Currency.Get(myType));
        myType = _type;
    }
}   