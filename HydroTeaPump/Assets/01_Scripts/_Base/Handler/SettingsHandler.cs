using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsHandler : MonoBehaviour, IDataHandler
{
    public void HandleData(string json)
    {
        // Json ==> SettingsVO
        DataVO data = JsonUtility.FromJson<DataVO>(json);
        SettingsVO settings = JsonUtility.FromJson<SettingsVO>(data.payload);

        
    }
}
