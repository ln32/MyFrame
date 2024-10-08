using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GachaSample : MonoBehaviour
{
    [SerializeField]SampleResultData data = new();
    MyGachaHandler myGachaHandler;
    public iGachaProcessHandler<int, SampleResultData> mGH => myGachaHandler;

    [SerializeField] FloatArrayData tableData;

    [ContextMenu("cnt")]
    void myFunc()
    {
        myGachaHandler = new(1, data, tableData);
        mGH.ExcuteGacha();
    }
}

class MyGachaHandler : iGachaProcessHandler<int, SampleResultData>
{
    FloatArrayData data;
    public int myData => _myData;
    public SampleResultData ResultData => _ResultData;

    int _myData;
    SampleResultData _ResultData;

    public MyGachaHandler(int input_1, SampleResultData input_2, FloatArrayData _data)
    {
        data = _data;
        _myData = input_1;
        _ResultData = input_2;
    }

    public void ApplyResult(SampleResultData _ReturnData)
    {
        Debug.Log("ApplyResult");
    }

    public bool AvailableCheck()
    {
        Debug.Log("AvailableCheck");
        return true;
    }

    public float[] GetTargetTable(int myData)
    {
        Debug.Log("GetTargetTable");
        return null;//data.floatArrays;
    }

    public void NotAvailableAction()
    {
        Debug.Log("NotAvailableAction");
    }

    public SampleResultData SetReturnData(int returnValue)
    {
        Debug.Log("NotAvailableAction " + returnValue);
        return null;
    }

    public void SetTicketDelta()
    {
        Debug.Log("SetTicketDelta");
    }

    public void SuccessAction(SampleResultData _ReturnData)
    {
        Debug.Log("SuccessAction");
    }
}

[Serializable]
public class SampleResultData
{
    string ResultName;
    int myIndex;
}