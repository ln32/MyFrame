using FuncSet_CreateGUI;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TestPresenter_TestEnum : MonoBehaviour, DataInterface<TestEnum>
{
    [SerializeField] ObservingGUI _prefab;
    List<ObservingGUI_Generial<TestEnum>> _observingGUIs = new List<ObservingGUI_Generial<TestEnum>>();

    #region SetDataInterface
    public Transform _transform => this.transform;
    ObservingGUI DataInterface<TestEnum>._prefab => this._prefab;
    public IManagingDataHandler<TestEnum, int> _handler => DataManager.instance.TestEnum;
    List<ObservingGUI_Generial<TestEnum>> DataInterface<TestEnum>._observingGUIs => this._observingGUIs;
    #endregion


    private void Awake()
    {
        CreateGUI();
    }

    [ContextMenu("CreateGUI")]
    public void CreateGUI()
    {
        this.CreateFunc();
    }

    [ContextMenu("RemoveGUI")]
    public void RemoveGUI()
    {
        this.RemoveFunc();
    }
}
