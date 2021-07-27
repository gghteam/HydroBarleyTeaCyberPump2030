using System;

[Serializable]
public class StageVO
{
    public bool[] stageClearStatus = new bool[5];

    public StageVO(bool[] stageClearStatus)
    {
        for (int i = 0; i < stageClearStatus.Length; ++i)
        {
            this.stageClearStatus[i] = stageClearStatus[i];
        }
    }
}
