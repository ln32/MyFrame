using UnityEngine;
using System;


// 평범한 observing
public class ObservingData<T>
{
    private T _value;

    public T Data
    {
        get
        {
            return this._value;
        }
        set
        {
            try
            {
                if (isAvailable.Invoke(value) == false)
                {
                    throw new ArgumentException("Parameter is not Available", nameof(T));
                }

                this._value = value;
                this.onChange?.Invoke(value);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public Func<T,bool> isAvailable = new((value) => {return true; });
    public Action<T> onChange = new((value) => {; });
}