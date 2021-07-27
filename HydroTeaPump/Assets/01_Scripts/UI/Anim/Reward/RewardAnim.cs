using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardAnim : MonoBehaviour
{
    [SerializeField] private Animation anim;

    delegate void Callback();

    void Start()
    {
        StartCoroutine(PlayAnim());
    }

    /// <summary>
    /// 피슝 에니메이션 재생
    /// </summary>
    /// <param name="callback">에니메이션 끝나면 재생</param>
    /// <returns></returns>
    IEnumerator PlayAnim(Callback callback = null)
    {
        anim.Play();

        while (anim.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }

        callback?.Invoke();
    }
}
