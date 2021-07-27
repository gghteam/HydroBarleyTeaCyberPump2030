using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RythmPlayerMove : GeneralMove
{
    private Animator          animator;
    private RhythmPlayerInput input; // �Է�

    public NoteManager noteManager;

    private void Start()
    {
        animator = GetComponent<Animator>();
        input    = GetComponent<RhythmPlayerInput>();
    }
    /// <summary>
    /// �÷��̾� �̵��Լ�
    /// </summary>
    public void PlayerMoving()
    {
        float h = input.right ? 1 : (input.left ? -1 : 0);
        float v = input.up ? 1    : (input.down ? -1 : 0);
        if (h != 0)
        {
            v = 0;
        }

        isMoving = true;

        Vector3 dir = new Vector3(h, v, 0); // 1, 0, -1 : h, v
        transform.localScale = new Vector3(h!=0? -h/2:transform.localScale.x, 0.5f, 1);
        Moving(dir);
    }

    private void Update()
    {
        animator.SetBool("Run", isMoving);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 11)  //��ǥ���� ����������
        {
            Debug.Log("��! ȹ��!");
            noteManager.canAct = false;
            SceneLoadManager.LoadSceneAdditive("RewardScene");
        }
        else if(col.gameObject.layer == 12)//����
        {
            Debug.Log("�� ����!");
        }
    }
    
}
