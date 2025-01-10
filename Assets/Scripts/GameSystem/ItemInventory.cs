using System;
using System.Collections.Generic;

[Serializable]
public class ItemInventory
{
    public int maxItemCount = 20;
    public List<Item> ItemList = new();

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
        }
    }

    public void Remove(Item item)
    {
        ItemList.Remove(item);
    }
}