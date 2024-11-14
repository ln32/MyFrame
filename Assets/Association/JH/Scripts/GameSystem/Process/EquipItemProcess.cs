using System;
using UnityEngine;

public static class EquipItemProcess
{
    public static Item EquipItem(MainGameCharacter targetCharacter, IEquipable item)
    {
        Item oldItem = null;
        try
        {
            if (targetCharacter == null)
                throw new ArgumentException("Null Character");

            var equipPart = item.EquipPart;
            var equips = targetCharacter.EquipItemPlatform.equipItems;
            IBattlePropertyComposition EquipItemPlatform = targetCharacter.EquipItemPlatform;

            var target = item as Item;

            if (item == null)
                throw new ArgumentException("Null Equip");

            if (item.CanEquip(targetCharacter) == false)
                throw new ArgumentException("Cant Equip");

            equips.TryGetValue(equipPart, out oldItem);

            if (oldItem != null)
            {
                equips.Remove(equipPart);
                (oldItem as IEquipable).ApplyUnequipSpec(EquipItemPlatform);
            }

            equips.Add(equipPart, target);
            item.ApplyEquipSpec(EquipItemPlatform);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        return oldItem;
    }

    public static Item UnequipItem(MainGameCharacter basePlatform, EquipPart equipPart)
    {
        Item oldItem = null;
        var equips = basePlatform.EquipItemPlatform.equipItems;
        IBattlePropertyComposition EquipItemPlatform = basePlatform.EquipItemPlatform;

        try
        {
            equips.TryGetValue(equipPart, out oldItem);

            if (oldItem != null)
            {
                equips.Remove(equipPart);
                (oldItem as IEquipable).ApplyUnequipSpec(EquipItemPlatform);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        return oldItem;
    }
}