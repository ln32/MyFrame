
using System;

public interface IManagingDataHandler<TEnum, T>
{
    void AddEvent(TEnum type, Action<T> interactFunc);

    void RemoveEvent(TEnum type, Action<T> interactFunc);

    T Get(TEnum type);

    void Set(TEnum type, T value);
}