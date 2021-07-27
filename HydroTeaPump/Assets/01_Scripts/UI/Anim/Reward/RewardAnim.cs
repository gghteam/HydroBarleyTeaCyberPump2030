using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardAnim : MonoBehaviour
{
    private Animation anim;
    private Animator animator;

    delegate void Callback();

    GameObject obj;

    private bool canGoNext = false;

    void Start()
    {
        anim = GetComponent<Animation>();
        animator = GetComponent<Animator>();
        obj = GameObject.Find("CutScene");
        if (obj != null)
        {
            StartCoroutine(PlayAnim(() => canGoNext = true));
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canGoNext)
        {
            if (gameObject.activeSelf)
                AfterAnim();
        }
    }
    private void AfterAnim()
    {
        obj.GetComponent<CutScene>().isPlayed = true;
        obj.GetComponent<CutScene>().PopPop();
        gameObject.SetActive(false);
    }
    /// <summary>
    /// 피슝 에니메이션 재생
    /// </summary>
    /// <param name="callback">에니메이션 끝나면 재생</param>
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
