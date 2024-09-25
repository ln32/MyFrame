using DataSet;
using FuncSet_CreateGUI;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestPresenter_Currency : MonoBehaviour, DataInterface<DefaultCurrency>
{
    [SerializeField] ObservingGUI _prefab;
    List<ObservingGUI_Generial<DefaultCurrency>> _observingGUIs = new List<ObservingGUI_Generial<DefaultCurrency>>();


    #region SetDataInterface
    public Transform _transform => this.transform;
    ObservingGUI DataInterface<DefaultCurrency>._prefab => this._prefab;
    public IManagingDataHandler<DefaultCurrency, int> _handler => DataManager.instance.Currency;
    List<ObservingGUI_Generial<DefaultCurrency>> DataInterface<DefaultCurrency>._observingGUIs => this._observingGUIs;
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
