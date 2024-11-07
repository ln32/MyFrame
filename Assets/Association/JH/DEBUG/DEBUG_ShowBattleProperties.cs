using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class DEBUG_ShowBattleProperties : MonoBehaviour
{
    public TextMeshProUGUI prefabs;
    public SerializedDictionary<string, TextMeshProUGUI> showSpec;
    Action clear;
    [Button]
    void InitFunc()
    {
        clear?.Invoke();
        clear = null;

        foreach (var item in showSpec)
        {
            DestroyImmediate(item.Value.gameObject);
        }
        showSpec.Clear();

        Type baseType = typeof(BattleProperty); // 특정 클래스 타입 지정
        List<Type> derivedTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsSubclassOf(baseType))
            .ToList();

        var dataManager = DataManager.instance;
        foreach (var item in derivedTypes)
        {
            TextMeshProUGUI ins = Instantiate(prefabs, transform);
            showSpec.Add(item.Name, ins);
            dataManager.AddValue(item.Name);
            Action<int> action = (int value) => SyncText(ins, item.Name, value);
            dataManager.AddAction(item.Name, action,true);
            clear += () => dataManager?.RemoveAction(item.Name, action);
        }
    }

    void SyncText(TextMeshProUGUI showSpec, string key, int value)
    {
        showSpec.text = key + " / " + value;
    }
}
