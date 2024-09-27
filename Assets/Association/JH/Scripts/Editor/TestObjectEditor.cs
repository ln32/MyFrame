using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(JH_Test))]
public class ItemEffectTriggerEditor : Editor //Monobehaviour 대신 Editor를 넣습니다.
{


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        JH_Test itemtrigger = (JH_Test)target;

        EditorGUILayout.BeginHorizontal(); 
        GUILayout.FlexibleSpace(); 

        if (GUILayout.Button("GoldCoin++", GUILayout.Width(100), GUILayout.Height(20)))
        {
            itemtrigger.Func_1();
        }
        if (GUILayout.Button("index += Gold", GUILayout.Width(100), GUILayout.Height(20)))
        {
            itemtrigger.Func_2();
        }
        GUILayout.FlexibleSpace();  // 고정된 여백을 넣습니다.
        EditorGUILayout.EndHorizontal();  // 가로 생성 끝

    }
}

