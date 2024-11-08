using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Rendering;

public class DEBUG_MainCharToShow : MonoBehaviour
{
    public MainGameCharacter mc;

    public string toshow = "";
    public SerializedDictionary<EquipPart, Item> equipItems;

    [Button]
    public void InitFunc()
    {
        mc.Start();
        toshow = mc.Level + " / " + (mc.BattleClass).GetType().Name;
        foreach (var item in equipItems)
        {
            if (mc.EquipItemPlatform.equipItems.ContainsKey(item.Key))
                equipItems[item.Key] = mc.EquipItemPlatform.equipItems[item.Key];
            else
                equipItems.Remove(item.Key);
        }

    }
}
