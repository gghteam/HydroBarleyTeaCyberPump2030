using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPoolManager<T> where T : class, IDisable, new()
{
    // 풀링용으로 사용되는 Queue
    private Queue<T> objQueue = new Queue<T>();


    public GenericPoolManager(T obj, int startSize = 5)
    {
        for (int i = 0; i < startSize; ++i)
        {
            objQueue.Enqueue(obj);
            obj.IsEnabled = false;
        }
    }

    public T GetObject()
    {
        T obj = default;

        if (objQueue.Count == 0)
        {
            obj = new T();
        }
        else
        {
            obj = objQueue.Dequeue();
        }

        obj.IsEnabled = true;
        
        objQueue.Enqueue(obj);

        return obj;
    }


    #region Utility



    #endregion
}
