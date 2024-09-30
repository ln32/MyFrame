using DataSet;
using FuncSet_CreateGUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public interface iManagingDataHandler<TEnum, T>
{
    void AddEvent(TEnum type, Action<T> interactFunc);

    void RemoveEvent(TEnum type, Action<T> interactFunc);

    T Get(TEnum type);

    void Set(TEnum type, T value);

    // 그냥 set( get()+value ) 간편화 시킨 함수
    void SetDelta(TEnum type, T value);    
}


public abstract class ManagingEnumData<TEnum, T> : iManagingDataHandler<TEnum, T> where TEnum : Enum
{
    // 유효성검사
    abstract internal bool IsAvailable(TEnum index, T input, bool semiCheck = true);

    #region Set iManagingDataHandler
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
        if (IsAvailable(type,value))
        {
            DataSet[type].Data = value;
        }
    }

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
    #endregion
}

