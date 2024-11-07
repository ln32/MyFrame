using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class DEBUG_MainCharToShow : MonoBehaviour
{
    public MainGameCharacter mc;

    public string toshow = "";
    public SerializedDictionary<EquipPart, Item> equipItems;

    [Button]
    void InitFunc()
    {
        toshow = mc.Level + " / " + (mc.BattleClass).GetType().Name;
        equipItems = mc.EquipItemPlatform.equipItems;
    }


}