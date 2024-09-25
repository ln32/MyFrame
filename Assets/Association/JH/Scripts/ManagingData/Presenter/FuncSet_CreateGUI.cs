using System;
using System.Collections.Generic;
using UnityEngine;
using Transform = UnityEngine.Transform;

namespace FuncSet_CreateGUI
{
    public static class FuncSet_CreateGUI
    {
        static public void MyCreateFunc<TEnum>(this DataInterface<TEnum> _data)
        {
            Transform _trans = _data._transform;
            ObservingGUI _prefab = _data._prefab;
            IManagingDataHandler<TEnum, int> _handler = _data._handler;
            List<ObservingGUI_Generial<TEnum>> _observingGUIs = _data._observingGUIs;


            RemoveFunc(_trans);
            _observingGUIs.Clear();

            int count = 0;
            foreach (TEnum type in Enum.GetValues(typeof(TEnum)))
            {
                ObservingGUI insGUI = UnityEngine.Object.Instantiate(_prefab, _trans);
                ObservingGUI_Generial<TEnum> ins = new ObservingGUI_Generial<TEnum>();
                if (true)
                {
                    insGUI.transform.position += Vector3.down * (count * 100);
                    _observingGUIs.Add(ins);

                    insGUI.OnEnableEvent += () => {
                        _handler.AddEvent(type, insGUI.ReactEvent); insGUI.isSet = true;
                        ins.SetType(insGUI, type, _handler.Get(type));
                    };

                    insGUI.OnDisableEvent += () => {
                        if (!DataManager.instance)
                            return; _handler.RemoveEvent(type, insGUI.ReactEvent);
                        insGUI.isSet = false;
                    };

                    insGUI.gameObject.SetActive(true);
                }

                count++;
            }
        }

        static public void CreateFunc<TEnum>(Transform tras, ObservingGUI _prefab, IManagingDataHandler<TEnum,int> _handler, List<ObservingGUI_Generial<TEnum>> _observingGUIs)
        {
            RemoveFunc(tras);
            _observingGUIs.Clear();

            int count = 0;
            foreach (TEnum type in Enum.GetValues(typeof(TEnum)))
            {
                ObservingGUI insGUI = UnityEngine.Object.Instantiate(_prefab, tras);
                ObservingGUI_Generial<TEnum> ins = new ObservingGUI_Generial<TEnum>();
                if (true)
                {
                    insGUI.transform.position += Vector3.down * (count * 100);
                    _observingGUIs.Add(ins);

                    insGUI.OnEnableEvent += () => {
                        _handler.AddEvent(type, insGUI.ReactEvent); insGUI.isSet = true;
                        ins.SetType(insGUI, type, _handler.Get(type));
                    };

                    insGUI.OnDisableEvent += () => {
                        if (!DataManager.instance)
                            return; _handler.RemoveEvent(type, insGUI.ReactEvent);
                        insGUI.isSet = false;
                    };

                    insGUI.gameObject.SetActive(true);
                }

                count++;
            }
        }

        static public void RemoveFunc(Transform tras)
        {
            foreach (Transform child in tras)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

    public interface DataInterface<TEnum>
    {
        Transform _transform { get; }
        ObservingGUI _prefab { get; }
        IManagingDataHandler<TEnum, int> _handler { get; }
        List<ObservingGUI_Generial<TEnum>> _observingGUIs { get; }
    }
}

