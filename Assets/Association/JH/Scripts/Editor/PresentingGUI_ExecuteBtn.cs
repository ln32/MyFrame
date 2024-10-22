using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PresentingTool_Default))]
public class PresentingGUI_ExecuteBtn : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PresentingTool_Default itemtrigger = (PresentingTool_Default)target;

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Refresh", GUILayout.Width(100), GUILayout.Height(20)))
        {
            itemtrigger.Refresh();
        }
        GUILayout.FlexibleSpace();  // 고정된 여백을 넣습니다.
        EditorGUILayout.EndHorizontal();  // 가로 생성 끝
    }
}
