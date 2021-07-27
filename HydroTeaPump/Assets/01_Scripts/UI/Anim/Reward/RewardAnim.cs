using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardAnim : MonoBehaviour
{
    private Animation anim;
    private Animator animator;

    delegate void Callback();

    void Start()
    {
        anim = GetComponent<Animation>();
        animator = GetComponent<Animator>();
        StartCoroutine(PlayAnim(() => Debug.Log("Asdasd")));
    }

    /// <summary>
    /// �ǽ� ���ϸ��̼� ���
    /// </summary>
    /// <param name="callback">���ϸ��̼� ������ ���</param>
    /// <returns></returns>
    IEnumerator PlayAnim(Callback callback = null)
    {
        animator.Play("reward");
        
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("reward"))
        {
            yield return new WaitForEndOfFrame();
        }

        callback?.Invoke();
    }
}
