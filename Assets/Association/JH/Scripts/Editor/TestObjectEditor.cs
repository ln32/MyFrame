using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(JH_Test))]
public class ItemEffectTriggerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        JH_Test itemtrigger = (JH_Test)target;

        EditorGUILayout.BeginHorizontal(); 
        GUILayout.FlexibleSpace(); 

        if (GUILayout.Button("+= value", GUILayout.Width(100), GUILayout.Height(20)))
        {
            itemtrigger.Func_1(); 
        }
        if (GUILayout.Button("*= value", GUILayout.Width(100), GUILayout.Height(20)))
        {
            itemtrigger.Func_2();
        }
        GUILayout.FlexibleSpace();  // 고정된 여백을 넣습니다.
        EditorGUILayout.EndHorizontal();  // 가로 생성 끝

    }
}

