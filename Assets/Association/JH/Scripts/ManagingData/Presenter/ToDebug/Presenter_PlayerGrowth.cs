using DataSet;
using FuncSet_CreateGUI;
using System.Collections.Generic;
using UnityEngine;

public class Presenter_PlayerGrowth : MonoBehaviour, Debug_DataInterface<PlayerGrowth>
{
    [SerializeField] ObservingGUI _prefab;
    List<ObservingGUI_Generial<PlayerGrowth>> _observingGUIs = new List<ObservingGUI_Generial<PlayerGrowth>>();


    #region SetDataInterface
    public Transform _transform => this.transform;
    ObservingGUI Debug_DataInterface<PlayerGrowth>._prefab => this._prefab;
    public iManagingDataHandler<PlayerGrowth, int> _handler => DataManager.instance.PlayerGrowth;
    List<ObservingGUI_Generial<PlayerGrowth>> Debug_DataInterface<PlayerGrowth>._observingGUIs => this._observingGUIs;
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
