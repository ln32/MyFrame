using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Rendering;

public class DEBUG_MainCharToShow : MonoBehaviour
{
    public MainCharacter mc;

    public string toshow = "";
    public SerializedDictionary<string, int> toshows;
    public SerializedDictionary<EquipPart, Item> equipItems;

    [Button]
    void InitFunc()
    {
        mc = FindAnyObjectByType<MainCharacter>();  

        toshow = mc.Level + " / " + (mc.BattleClass).GetType().Name;
        toshows = mc.EquipItemPlatform.properties;
        equipItems = mc.EquipItemPlatform.equipItems;
    }
}