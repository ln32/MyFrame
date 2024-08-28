using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_Creator : MonoBehaviour
{
    [SerializeField] ObservingGUI _prefab;

    [ContextMenu("CreateGUI")]
    public void CreateFunc()
    {
        int count = 0;
        foreach (CurrencyType_Int type in Enum.GetValues(typeof(CurrencyType_Int)))
        {
            _prefab.SetType(type);
            ObservingGUI ins = Instantiate(_prefab, transform);
            ins.transform.position +=Vector3.down * (count * 100);

            count++;
        }
    }

    [ContextMenu("RemoveGUI")]
    public void RemoveFunc()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
