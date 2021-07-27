using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftAnim : MonoBehaviour
{
    [SerializeField] private Animator animator; // ���ϸ�����
    [SerializeField] private Image[] images = new Image[0]; // ���ϸ��̼� ��� �̹���
     private CraftUI craft; // �������̺� ��������Ʈ �뵵


    private void Awake()
    {
        craft = GetComponent<CraftUI>();
    }


    void Start()
    {


        images[0].gameObject.SetActive(false);
        images[1].gameObject.SetActive(false);
        images[2].gameObject.SetActive(false);
    }
    

    public void Animation()
    {
        images[0].sprite = craft.GetTable()[0].image.sprite;
        images[1].sprite = craft.GetTable()[1].image.sprite;
        images[2].sprite = craft.GetTable()[2].image.sprite;
        
        images[0].gameObject.SetActive(true);
        images[1].gameObject.SetActive(true);
        images[2].gameObject.SetActive(true);

        animator.SetBool("clear", craft.Success());
        animator.Play("Craft");
        animator.SetTrigger("Craft");

        FailedManager.AddSuccessInfo(craft.GetWhatIsWrong());

    }
}
