using System;

[Serializable]
public class InventoryVO
{
    public ItemVO[] items = new ItemVO[6];


    public InventoryVO(ItemVO[] items)
    {
        for (int i = 0; i < items.Length; ++i)
        {
            this.items[i] = items[i];
        }
    }
}