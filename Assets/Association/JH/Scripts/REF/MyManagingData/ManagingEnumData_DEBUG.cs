using DataSet;
using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public abstract class ManagingEnumData_DEBUG<TEnum,T> : MonoBehaviour, IManagingDataHandler_Int<TEnum,T> where TEnum : Enum
{
    public List<T> DataListUp = new List<T>();
    public List<string> DeligateListUp = new List<string>();

    internal Dictionary<TEnum, ManagingData<T>> DataSet = null;

    public ManagingEnumData_DEBUG()
    {
        DataSet = new Dictionary<TEnum, ManagingData<T>>();

        foreach (TEnum type in Enum.GetValues(typeof(TEnum)))
        {
            DataSet[type] = new ManagingData<T>();

            if (typeof(T) == typeof(string))
            {
                DataListUp.Add((T)(object)"default");
            }else
                DataListUp.Add((T)(object)0);
        }
    }

    public void AddEvent(TEnum type, Action<T> interactFunc)
    {
        DataSet[type].onChange += interactFunc;
        DeligateListUp.Add(type + " / " + interactFunc.Method.Name);
    }

    public void RemoveEvent(TEnum type, Action<T> interactFunc)
    {
        DataSet[type].onChange -= interactFunc;
        DeligateListUp.Remove(type + " / " + interactFunc.Method.Name);
    }

    public T Get(TEnum type)
    {
        return DataSet[type].Data;
    }


    public void Set(TEnum type, T value)
    {
        DataSet[type].Data = value;
        DataListUp[(int)(object)type] = DataSet[type].Data;
    }

    public void SetDelta(TEnum type, T value)
    {
        try
        {
            if (typeof(T) == typeof(int))
            {
                var result = (int)(object)(DataSet[type].Data) + (int)(object)(value);
                DataSet[type].Data = (T)(object)result;
            }
            else if (typeof(T) == typeof(short))
            {
                var result = (short)(object)(DataSet[type].Data) + (short)(object)(value);
                DataSet[type].Data = (T)(object)result;
            }
            else if (typeof(T) == typeof(double))
            {
                var result = (double)(object)(DataSet[type].Data) + (double)(object)(value);
                DataSet[type].Data = (T)(object)result;
            }
            else if (typeof(T) == typeof(char))
            {
                var result = (char)(object)(DataSet[type].Data) + (char)(object)(value);
                DataSet[type].Data = (T)(object)result;
            }
            else return;

            DataListUp[(int)(object)type] = DataSet[type].Data;
        }
        catch (Exception)
        {
            throw new InvalidOperationException("덧셈이 불가능한 타입입니다.");
        }
    }
}