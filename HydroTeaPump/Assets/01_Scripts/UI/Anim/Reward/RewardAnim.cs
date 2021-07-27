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
        obj = GameObject.Find("cvsCutScene");
        if (obj != null)
        {
            StartCoroutine(PlayAnim(() => canGoNext = true));
            Debug.Log("Find");
        }
        else
        {
            Debug.Log("CantFind");
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canGoNext)
        {
            if (gameObject.activeSelf)
            {
                AfterAnim();
            }
        }
    }
    private void AfterAnim()
    {
        gameObject.SetActive(false);
        SceneLoadManager.LoadSceneAdditive("CutSceneScene");
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
