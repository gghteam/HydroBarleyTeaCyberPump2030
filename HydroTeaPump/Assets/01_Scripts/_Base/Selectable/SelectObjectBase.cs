using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObjectBase : MonoBehaviour, ICollSelectable
{
    public virtual void OnSelect()
    {
        Debug.Log($"I am selected!, Name: {gameObject.name}");
    }
    
    public virtual void ToggleNotice()
    {
        
    }
}
