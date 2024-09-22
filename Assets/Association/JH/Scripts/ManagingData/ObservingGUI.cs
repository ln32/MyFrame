using DataSet;
using System;
using TMPro;
using UnityEngine;

public class ObservingGUI : MonoBehaviour
{
    [SerializeField] internal TextMeshProUGUI fixedTMP;
    [SerializeField] internal TextMeshProUGUI valueTMP;
    [SerializeField] internal CurrencyType_Int myType = CurrencyType_Int.Gold;
    [SerializeField] internal bool isSet = false;
    internal Action OnEnableEvent;
    internal Action OnDisableEvent;


    internal void ReactEvent(int value)
    {
        valueTMP.text = value + "";
        valueTMP.ForceMeshUpdate();
    }

    // Fix Text 수정을 위한 함수, Ruby Dia 등등...
    internal void SetType(CurrencyType_Int _type, int value)
    {
        transform.name = _type.ToString();
        fixedTMP.text = _type.ToString() + " : ";
        valueTMP.text = value + "";

        myType = _type;
        valueTMP.ForceMeshUpdate();
    }

    private void OnEnable()
    {
        if (isSet == false)
            OnEnableEvent?.Invoke();
    }

    private void OnDisable()
    {
        if (isSet == true)
            OnDisableEvent?.Invoke();
    }
}   