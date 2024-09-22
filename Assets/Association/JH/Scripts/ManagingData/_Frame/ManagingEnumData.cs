using DataSet;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ManagingEnumData<TEnum,T> : IManagingDataHandler<TEnum,T> where TEnum : Enum
{
    internal Dictionary<TEnum, ManagingData<T>> DataSet = null;

    public ManagingEnumData()
    {
        DataSet = new Dictionary<TEnum, ManagingData<T>>();

        foreach (TEnum type in Enum.GetValues(typeof(TEnum)))
        {
            DataSet[type] = new ManagingData<T>();
        }
    }

    public void AddEvent(TEnum type, Action<T> interactFunc)
    {
        DataSet[type].onChange += interactFunc;
    }

    public void RemoveEvent(TEnum type, Action<T> interactFunc)
    {
        DataSet[type].onChange -= interactFunc;
    }

    public T Get(TEnum type)
    {
        return DataSet[type].Data;
    }
    
    public void Set(TEnum type, T value)
    {
        if (IsAvailable(value))
        {
            DataSet[type].Data = value;
        }
    }

    abstract internal bool IsAvailable(T type);

    public void SetDelta(TEnum type, T value)
    {
        try
        {
            if (typeof(T) == typeof(int))
            {
                var result = (int)(object)(DataSet[type].Data) + (int)(object)(value);
                DataSet[type].Data = (T)(object)result;
                return;
            }
            else if (typeof(T) == typeof(short))
            {
                var result = (short)(object)(DataSet[type].Data) + (short)(object)(value);
                DataSet[type].Data = (T)(object)result;
                return;
            }
            else if (typeof(T) == typeof(double))
            {
                var result = (double)(object)(DataSet[type].Data) + (double)(object)(value);
                DataSet[type].Data = (T)(object)result;
                return;
            }
            else if (typeof(T) == typeof(char))
            {
                var result = (char)(object)(DataSet[type].Data) + (char)(object)(value);
                DataSet[type].Data = (T)(object)result;
                return;
            }
        }
        catch (Exception)
        {
            throw new InvalidOperationException("덧셈이 불가능한 타입입니다.");
        }
    }
}
