using FuncSet_CreateGUI;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TestPresenter_TestEnum : MonoBehaviour
{
    [SerializeField] ObservingGUI _prefab;
    List<ObservingGUI_Generial<TestEnum>> _observingGUIs = new List<ObservingGUI_Generial<TestEnum>>();

    private void Awake()
    {
        CreateFunc();
    }

    [ContextMenu("CreateGUI")]
    public void CreateFunc()
    {
        FuncSet_CreateGUI.FuncSet_CreateGUI.CreateFunc(transform, _prefab, DataManager.instance.TestEnum, _observingGUIs);
    }

    [ContextMenu("RemoveGUI")]
    public void RemoveFunc()
    {
        FuncSet_CreateGUI.FuncSet_CreateGUI.RemoveFunc(transform);
    }
}
