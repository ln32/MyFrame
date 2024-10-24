using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DataChangeConsole))]
public class Editor_DataChangeConsole : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DataChangeConsole itemtrigger = (DataChangeConsole)target;

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        if (GUILayout.Button("string", GUILayout.Width(50), GUILayout.Height(20)))
        {
            itemtrigger.SetValue_string();
        }

        if (GUILayout.Button("int", GUILayout.Width(50), GUILayout.Height(20)))
        {
            itemtrigger.SetValue_int();
        }

        if (GUILayout.Button("Sprite", GUILayout.Width(50), GUILayout.Height(20)))
        {
            itemtrigger.SetValue_Sprite();
        }
        GUILayout.FlexibleSpace();  // 고정된 여백을 넣습니다.
        EditorGUILayout.EndHorizontal();  // 가로 생성 끝
    }
}
