using System;
using UnityEditor;
using static UnityEditor.Progress;

public interface iManagningGUI<T>
{
    Action<T> Reaction { get; }
    Action OnEnableAction { get; }
    Action OnDisableAction { get; }
}

internal static class Expand_iManagningGUI
{
    static public void SetObserving<TEnum,T>(this iManagingDataHandler<TEnum,T> _handler, TEnum _data, iManagningGUI<T> _gui, bool onInvoke = false)
    {
        Action OnEnableAction = _gui.OnEnableAction;
        Action OnDisableAction = _gui.OnDisableAction;
        Action<T> Reaction = _gui.Reaction;

        OnEnableAction += () => _handler.AddEvent(_data, Reaction);
        OnDisableAction += () => _handler.RemoveEvent(_data, Reaction);

        _handler.AddEvent(_data, Reaction);

        if (onInvoke)
            Reaction?.Invoke(_handler.Get(_data));
    }
}