using DataSet;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TestPresenter_Currency : MonoBehaviour
{
    [SerializeField] ObservingGUI _prefab;
    List<ObservingGUI> _observingGUIs = new List<ObservingGUI>();

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
        foreach (CurrencyType_Int type in Enum.GetValues(typeof(CurrencyType_Int)))
        {
            ObservingGUI ins = Instantiate(_prefab, transform);

            if (true)
            {
                ins.transform.position += Vector3.down * (count * 100);
                _observingGUIs.Add(ins);

                ins.OnEnableEvent += () => { DataManager.instance.Currency.AddEvent(type, ins.ReactEvent); ins.isSet = true; };
                ins.OnDisableEvent += () => {
                    if (!DataManager.instance)
                        return; DataManager.instance.Currency.RemoveEvent(type, ins.ReactEvent); 
                    ins.isSet = false; 
                };

                ins.SetType(type, DataManager.instance.Currency.Get(type));
                ins.gameObject.SetActive(true);
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
