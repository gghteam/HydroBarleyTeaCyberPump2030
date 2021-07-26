using System;

// 저장할수도있으니

[Serializable]
public class ItemVO
{
    public ItemEnum itemEnum;
    public int      count;
    public float    weight;

    public ItemVO(ItemEnum itemEnum, int count, float weight)
    {
        this.itemEnum = itemEnum;
        this.count    = count;
        this.weight   = weight;
    }

    public ItemVO(ItemVO vo)
    {
        this.itemEnum = vo.itemEnum;
        this.count    = vo.count;
        this.weight   = vo.weight;
    }
}