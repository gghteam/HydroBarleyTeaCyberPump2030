using System;

[Serializable]
public class SaveData
{
    public InventoryVO inventoryVO = InventoryBase.GetInventory();

    public bool isClear = false;
    public bool isStory = true;
    public bool isEnding = false;
    public bool isGoodEnding = false;

    public bool storyWatched = false;

}
