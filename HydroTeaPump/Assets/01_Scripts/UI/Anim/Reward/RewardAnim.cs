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
    /// �ǽ� ���ϸ��̼� ���
    /// </summary>
    /// <param name="callback">���ϸ��̼� ������ ���</param>
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
