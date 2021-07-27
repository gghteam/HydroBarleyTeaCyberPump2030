using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NULLChecker : MonoBehaviour
{
    /// <summary>
    /// 널체크 함수
    /// </summary>
    /// <param name="obj">체크할 것</param>
    /// <returns>true when null</returns>
    static public bool CheckNULL(object obj)
    {
#if UNITY_EDITOR

        if (obj == null)
        {
            Debug.LogWarning($"Type: {obj.GetType()} is null");
            return true;
        }
        return false;
#endif
#pragma warning disable CS0162 // 접근할 수 없는 코드가 있습니다.
        return false;
#pragma warning restore CS0162 // 접근할 수 없는 코드가 있습니다.
    }

    /// <summary>
    /// 널체크 함수
    /// </summary>
    /// <param name="obj">체크할 것(배열)</param>
    /// <returns>true when null</returns>
    static public bool CheckNULL(object[] obj)
    {
#if UNITY_EDITOR
        if (obj == null)
        {
            Debug.LogWarning($"Type: {obj.GetType()} array is null");
        }
        
        for(int i = 0; i < obj.Length; ++i)
        {
            if (obj[i] == null)
            {
                Debug.LogWarning($"Type: {obj.GetType()} 's element is null\r\nIndex: {i}");
                return true;
            }
        }

        return false;
#endif
#pragma warning disable CS0162 // 접근할 수 없는 코드가 있습니다.
        return false;
#pragma warning restore CS0162 // 접근할 수 없는 코드가 있습니다.
    }
}
