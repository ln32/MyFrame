using DataSet;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestPresenter_Currency : MonoBehaviour
{
    [SerializeField] ObservingGUI _prefab;
    List<ObservingGUI_Generial<DefaultCurrency>> _observingGUIs = new List<ObservingGUI_Generial<DefaultCurrency>>();

    private void Awake()
    {
        CreateFunc();
    }

    [ContextMenu("CreateGUI")]
    public void CreateFunc()
    {
        RemoveFunc();
        _observingGUIs.Clear();

        int count = 0;
        foreach (DefaultCurrency type in Enum.GetValues(typeof(DefaultCurrency)))
        {
            ObservingGUI insGUI = Instantiate(_prefab, transform);
            ObservingGUI_Generial<DefaultCurrency> ins = new ObservingGUI_Generial<DefaultCurrency>();
            if (true)
            {
                insGUI.transform.position += Vector3.down * (count * 100);
                _observingGUIs.Add(ins);

                insGUI.OnEnableEvent += () => { DataManager.instance.Currency.AddEvent(type, insGUI.ReactEvent); insGUI.isSet = true; };
                insGUI.OnDisableEvent += () => {
                    if (!DataManager.instance)
                        return; DataManager.instance.Currency.RemoveEvent(type, insGUI.ReactEvent);
                    insGUI.isSet = false; 
                };

                ins.SetType(insGUI, type, DataManager.instance.Currency.Get(type));
                insGUI.gameObject.SetActive(true);
            }

            count++;
        }
    }

    [ContextMenu("RemoveGUI")]
    public void RemoveFunc()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
