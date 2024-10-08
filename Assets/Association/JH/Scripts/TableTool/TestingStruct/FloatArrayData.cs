using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatArrayData", menuName = "ScriptableObjects/FloatArrayData", order = 1)]
public class FloatArrayData : ScriptableObject
{
    [SerializeField] public float[] TargetData;

    [SerializeField] public float[] NormalizeForm;
    [SerializeField] public float[] SnowballForm;

    private void OnValidate()
    {
        if (TargetData == null || TargetData.Length == 0 || TargetData[0] == 0)
        { 
            return; 
        }
        int length = TargetData.Length;
        float sum = 0f;

        NormalizeForm = new float[TargetData.Length];
        SnowballForm = new float[TargetData.Length];

        for (int i = 0; i < length; i++)
        {
            NormalizeForm[i] = TargetData[i];
            sum += TargetData[i];
            SnowballForm[i] = sum;
        }


        for (int i = 0; i < length; i++)
        {
            NormalizeForm[i] /= sum;
            SnowballForm[i] /= sum;
        }
    }
}