using System;
using UnityEngine;

public static class EquipItemProcess
{
    public static Item EquipItem(MainCharacter basePlatform, IEquipable item)
    {
        Item oldItem = null;
        var equipPart = item.EquipPart;
        var equips = basePlatform.EquipItemPlatform.equipItems;
        IBattlePropertyComposition EquipItemPlatform = basePlatform.EquipItemPlatform;

        try
        {
            var target = item as Item;

            if (item.CanEquip(basePlatform) == false)
                throw new ArgumentException("Cant Equip");

            equips.TryGetValue(equipPart, out oldItem);

            if (oldItem != null)
            {
                equips.Remove(equipPart);
                (oldItem as IEquipable).ApplyUnequipSpec(EquipItemPlatform);
            }

            if (target != null)
                equips.Add(equipPart, target);

            item.ApplyEquipSpec(EquipItemPlatform);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        return oldItem;
    }
}