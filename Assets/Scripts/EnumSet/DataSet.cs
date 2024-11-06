using System;
using System.Collections.Generic;
using UnityEngine;

namespace DataSet
{
    [Serializable]
    public class DataTypePairing<T, TEnum> where TEnum : Enum
    {
        public string PairingName { get; set; }
        public Type ParingType{ get; set; } = typeof(T);
        [SerializeField] public List<string> DataNameList;

        public DataTypePairing(){
            DataNameList = new();
            foreach (TEnum weapon in Enum.GetValues(typeof(TEnum)))
            {
                DataNameList.Add(weapon.ToString());
            }
        }
    }

    static public class DataTypePairingFunc
    {
        static public void RemoveAction<T, TEnum>(this DataTypePairing<T, TEnum> category, TEnum valueName, Action<T> action) where TEnum : Enum
        {
            DataManager.instance.RemoveAction(valueName.ToString(), action);
        }

        static public void AddAction<T, TEnum>(this DataTypePairing<T, TEnum> category, TEnum valueName, Action<T> action,bool isUpdate = false) where TEnum : Enum
        {
            DataManager.instance.AddAction(valueName.ToString(), action, isUpdate);
        }


        static public T GetValue<T, TEnum>(this DataTypePairing<T, TEnum> category, TEnum valueName) where TEnum : Enum
        {
            return DataManager.instance.GetValue<T>(valueName.ToString());
        }

        static public void SetValue<T, TEnum>(this DataTypePairing<T, TEnum> category, TEnum valueName, T value) where TEnum : Enum
        {
            DataManager.instance.SetValue(valueName.ToString(), value);
        }
    }
}