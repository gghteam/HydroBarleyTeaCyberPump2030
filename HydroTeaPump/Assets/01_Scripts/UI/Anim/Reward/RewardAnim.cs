using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardAnim : MonoBehaviour
{
    private Animation anim;
    private Animator animator;

    delegate void Callback();


    private bool canGoNext = false;

    [SerializeField]
    private Transform earnObj = null;

    [SerializeField]
    private Sprite[] earnObjSprites = null;
    void Start()
    {
        anim = GetComponent<Animation>();
        animator = GetComponent<Animator>();
        earnObj.GetComponent<Image>().sprite = earnObjSprites[GameManager.Instance.currentStage];
        StartCoroutine(PlayAnim(() => canGoNext = true));

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canGoNext)
        {
            canGoNext = false;
            if (gameObject.activeSelf)
            {
                AfterAnim();
            }
        }
    }
    private void AfterAnim()
    {
        GameSave.Instance.data.isStory = false;
        GameSave.Instance.data.isClear = true;
        SceneLoadManager.LoadSceneAdditive("CutSceneScene");
        SceneLoadManager.UnLoadScene("RewardScene");
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
