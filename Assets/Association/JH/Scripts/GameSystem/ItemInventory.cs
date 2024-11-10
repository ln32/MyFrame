using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemInventory
{
    public List<Item> ItemList = new List<Item>();
    public int maxItemCount = 20;

    public void Add(Item item)
    {
        try
        {
            if (maxItemCount < ItemList.Count)
                throw new Exception();

            ItemList.Add(item);
        }
        catch (Exception)
        {
            return;
        }
    }

    public void Remove(Item item)
    {
        ItemList.Remove(item);
    }
}