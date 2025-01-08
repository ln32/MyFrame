using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class DEBUG_MainCharToShow : MonoBehaviour
{
    public MainCharacter mc;

    public string toshow = "";
    public Dictionary<EquipPart, Item> equipItems;
    public Dictionary<string, int> toshows;

    [Button]
    private void InitFunc()
    {
        mc = FindAnyObjectByType<MainCharacter>();

        toshow = mc.Level + " / " + mc.BattleClass.GetType().Name;
        toshows = mc.EquipItemPlatform.properties;
        equipItems = mc.EquipItemPlatform.equipItems;
    }
}