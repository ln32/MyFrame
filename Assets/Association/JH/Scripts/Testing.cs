using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

    [ContextMenu("Func")]
    public void Func()
    {
        DataManager.instance.Currency.Set(CurrencyType_Int.Gold,10);
    }
}
