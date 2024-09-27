using FuncSet_CreateGUI;
using System.Collections.Generic;
using UnityEngine;

public class Presenter_DataEnum : MonoBehaviour, Debug_DataInterface<DataEnum>
{
    [SerializeField] ObservingGUI _prefab;
    List<ObservingGUI_Generial<DataEnum>> _observingGUIs = new List<ObservingGUI_Generial<DataEnum>>();

    #region SetDataInterface
    public Transform _transform => this.transform;
    ObservingGUI Debug_DataInterface<DataEnum>._prefab => this._prefab;
    public iManagingDataHandler<DataEnum, int> _handler => DataManager.instance.DataEnum;
    List<ObservingGUI_Generial<DataEnum>> Debug_DataInterface<DataEnum>._observingGUIs => this._observingGUIs;
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
