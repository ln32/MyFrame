using DataSet;
using System;
using TMPro;
using UnityEngine;

public class ObservingGUI : MonoBehaviour
{
    [SerializeField] internal TextMeshProUGUI fixedTMP;
    [SerializeField] internal TextMeshProUGUI valueTMP;
    [SerializeField] internal bool isSet = false;
    internal Action OnEnableEvent;
    internal Action OnDisableEvent;


    internal void ReactEvent(int value)
    {
        valueTMP.text = value + "";
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