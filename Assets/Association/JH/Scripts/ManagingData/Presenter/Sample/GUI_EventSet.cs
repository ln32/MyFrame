using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class GUI_EventSet : iManagningGUI<int>
{
    [SerializeField] internal DataEnum _dataEnum = DataEnum.GoldCoin;
    [SerializeField] public UnityEvent<int> eventSet;

    public Action _OnEnableAction;
    public Action _OnDisableAction;

    #region iReactingGUI<int> implementation
    public Action<int> Reaction => eventSet.Invoke;
    public Action OnEnableAction => _OnEnableAction;
    public Action OnDisableAction => _OnDisableAction;
    #endregion
}
