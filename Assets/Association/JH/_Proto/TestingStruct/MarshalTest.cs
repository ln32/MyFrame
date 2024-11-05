using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MarshalTest : MonoBehaviour
{
    public int index;
    public myData md;
    public int A;
    public float B;
    public string C;

    [ContextMenu("TesfFunc")]
    void myTest()
    {
    }
}


[Serializable]
public class myData
{
    public int A;
    public float B;
    public string C;
}


[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class Row
{
    public int A;
    public float B;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
    public string C;
}

public class Data
{
    public List<Row> Rows;
}

public static class Testbed
{
    public static Data LoadBytes(byte[] bytes, int rowCount)
    {
        var rowSize = Marshal.SizeOf(new Row());
        IntPtr buffer = Marshal.AllocHGlobal(rowSize);

        var dataSet = new Data();

        for (var i = 0; i < rowCount; i++)
        {
            Marshal.Copy(bytes, i * rowSize, buffer, rowSize);
            dataSet.Rows.Add(Marshal.PtrToStructure<Row>(buffer));
        }

        Marshal.FreeHGlobal(buffer);

        return dataSet;
    }
}