using DataSet;
using FuncSet_CreateGUI;
using System.Collections.Generic;
using UnityEngine;

public class TestPresenter_Currency : MonoBehaviour, DataInterface<Currency_Old>
{
    [SerializeField] ObservingGUI _prefab;
    List<ObservingGUI_Generial<Currency_Old>> _observingGUIs = new List<ObservingGUI_Generial<Currency_Old>>();


    #region SetDataInterface
    public Transform _transform => this.transform;
    ObservingGUI DataInterface<Currency_Old>._prefab => this._prefab;
    public IManagingDataHandler<Currency_Old, int> _handler => DataManager.instance.Currency;
    List<ObservingGUI_Generial<Currency_Old>> DataInterface<Currency_Old>._observingGUIs => this._observingGUIs;
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
