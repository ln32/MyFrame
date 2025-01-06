using System;


// 평범한 observing
public class ObservingData<T>
{
    private T _value;

    public Func<T, bool> isAvailable = value => { return true; };
    public Action<T> onChange = value => { ; };

    public T Data
    {
        get => _value;
        set
        {
            if (isAvailable.Invoke(value) == false)
                throw new ArgumentException("Parameter is not Available", nameof(T));

            _value = value;
            onChange?.Invoke(value);
        }
    }
}