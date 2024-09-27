using FuncSet_CreateGUI;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagingGUI_Sameple : MonoBehaviour, iManagningGUI<int>
{
    //public Action 
    [SerializeField] internal TextMeshProUGUI valueTMP;
    public DataEnum _dataEnum;

    public Action<int> _Reaction;
    public Action _OnEnableAction;
    public Action _OnDisableAction;

    #region iReactingGUI<int> implementation

    public Action<int> Reaction => _Reaction;
    public Action OnEnableAction => _OnEnableAction;
    public Action OnDisableAction => _OnDisableAction;
    #endregion

    public ManagingGUI_Sameple()
    {
        if (true)
        {
            // init value
            _Reaction = ReactFunc;
            _OnEnableAction = () => { };
            _OnDisableAction = () => { };
        }
    }

    public void ReactFunc(int value)
    {
        // React
        Debug.Log(_dataEnum + " <<");
        valueTMP.text = value.ToString();
    }

    private void OnEnable()
    {
        OnEnableAction?.Invoke();
    }

    private void OnDisable()
    {
        OnDisableAction?.Invoke();
    }
}
