using DataSet;
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
        RemoveFunc();
        _observingGUIs.Clear();

        int count = 0;
        foreach (TestEnum type in Enum.GetValues(typeof(TestEnum)))
        {
            ObservingGUI insGUI = Instantiate(_prefab, transform);
            ObservingGUI_Generial<TestEnum> ins = new ObservingGUI_Generial<TestEnum>();
            if (true)
            {
                insGUI.transform.position += Vector3.down * (count * 100);
                _observingGUIs.Add(ins);

                insGUI.OnEnableEvent += () => { 
                    DataManager.instance.TestEnum.AddEvent(type, insGUI.ReactEvent); insGUI.isSet = true;
                    ins.SetType(insGUI, type, DataManager.instance.TestEnum.Get(type));
                };

                insGUI.OnDisableEvent += () => {
                    if (!DataManager.instance)
                        return; DataManager.instance.TestEnum.RemoveEvent(type, insGUI.ReactEvent);
                    insGUI.isSet = false;
                };

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
