using System;


// 편의를 위한 인터페이스. Reaction - observing event / OnEnableAction - 할당 / OnDisableAction - 제거
public interface iManagningGUI<T>
{
    Action<T> Reaction { get; }
    Action OnEnableAction { get; }
    Action OnDisableAction { get; }
}

internal static class Expand_iManagningGUI
{
    // 위 인터페이스 만족 시 할당 제거 등록 매크로
    static public void SetObserving<TEnum, T>(this iManagingDataHandler<TEnum, T> _handler, TEnum _data, iManagningGUI<T> _gui, bool onInvoke = false)
    {
        Action OnEnableAction = _gui.OnEnableAction;
        Action OnDisableAction = _gui.OnDisableAction;
        Action<T> Reaction = _gui.Reaction;

        OnEnableAction += () => _handler.AddEvent(_data, Reaction);
        OnDisableAction += () => _handler.RemoveEvent(_data, Reaction);

        if (onInvoke)
        {
            _handler.AddEvent(_data, Reaction);
            Reaction?.Invoke(_handler.Get(_data));
        }
    }

    static public void SetObserving<T>(this ManagingData<T> _single, iManagningGUI<T> _gui, bool onInvoke = false)
    {
        Action OnEnableAction = _gui.OnEnableAction;
        Action OnDisableAction = _gui.OnDisableAction;
        Action<T> Reaction = _gui.Reaction;

        OnEnableAction += () => { _single.onChange += (Reaction); };
        OnDisableAction += () => { _single.onChange -= (Reaction); };


        if (onInvoke)
        {
            _single.onChange += (Reaction);
            Reaction?.Invoke(_single.Data);
        }
    }
}