using UI.Interactive.Button;


public class UIInteractiveManager : UnityEngine.MonoBehaviour
{
    private void Awake()
    {
        new Select();

        DontDestroyOnLoad(this);
    }
}


namespace UI
{

    namespace Interactive
    {
        using System.Collections.Generic;

        namespace Button
        {
            
            /// <summary>
            /// ����Ű�� �����ϴ� ����� ���� Ŭ����
            /// </summary>
            public class Select
            {
                static private Select inst;                        // static ���� �뵵
                       private int    index;                       // ���� �ε���
                       private List<UnityEngine.UI.Button> from;   // ������ ��ư�� TODO : Dictionary<int index, Button button> ���� �ٲٸ� ���.
                       private UnityEngine.KeyCode next;           // ���� ��ư���� �̵�
                       private UnityEngine.KeyCode prev;           // ���� ��ư���� �̵�
                       private UnityEngine.KeyCode select;         // ���� ��ư���� �̵�


                /// <summary>
                /// ����Ű�� �����ϴ� ����� ���� Ŭ����
                /// </summary>
                /// <param name="next">���� ��ư</param>
                /// <param name="prev">���� ��ư</param>
                public Select()
                {
                    from = new List<UnityEngine.UI.Button>();
                    inst = this;
                }

                #region �ʱ�ȭ

                /// <summary>
                /// ������ ��ư���� �߰��մϴ�.
                /// </summary>
                /// <param name="selectFrom">������ ��ư��</param>
                static public void SelectFrom(UnityEngine.UI.Button[] selectFrom, CallBack callback = null)
                {
                    inst.from.Clear();

                    for (int i = 0; i < selectFrom.Length; ++i)
                    {
                        inst.from.Add(selectFrom[i]);
                    }

                    callback?.Invoke();
                }

                /// <summary>
                /// ������ ��ư���� �߰��մϴ�.
                /// </summary>
                /// <param name="selectFrom">������ ��ư��</param>
                static public void SelectFrom(List<UnityEngine.UI.Button> selectFrom, CallBack callback = null)
                {
                    inst.from.Clear();

                    for (int i = 0; i < selectFrom.Count; ++i)
                    {
                        inst.from.Add(selectFrom[i]);
                    }

                    callback?.Invoke();
                }

                /// <summary>
                /// �̵� Ű ����
                /// </summary>
                /// <param name="next">���� ��ư �̵�</param>
                /// <param name="prev">���� ��ư �̵�</param>
                static public void SetKey(UnityEngine.KeyCode next, UnityEngine.KeyCode prev, UnityEngine.KeyCode select, CallBack callback = null)
                {
                    inst.next   = next;
                    inst.prev   = prev;
                    inst.select = select;

                    callback?.Invoke();
                }

                #endregion

                #region ����

                /// <summary>
                /// ������ ��ư�� �ϳ� �߰��մϴ�.
                /// </summary>
                /// <param name="selectFrom">������ ��ư</param>
                /// <param name="callback"></param>
                static public void AddFrom(UnityEngine.UI.Button selectFrom, CallBack callback = null)
                {
                    inst.from.Add(selectFrom);

                    callback?.Invoke();
                }

                /// <summary>
                /// ������ ��ư ����Ʈ�� �ʱ�ȭ�մϴ�.
                /// </summary>
                /// <param name="callback"></param>
                static public void Reset(CallBack callback = null)
                {
                    inst.from.Clear();

                    callback?.Invoke();
                }

                #endregion

                #region �̵�

                /// <summary>
                /// next Ű�� ���ȴٸ� �������� �̵�
                /// </summary>
                /// <param name="callback"></param>
                static public void MoveNext(CallBack callback = null)
                {
                    if (UnityEngine.Input.GetKeyDown(inst.next))
                    {
                        // ������ ������Ʈ ����Ʈ ������ �ε������� �ε���ī Ŀ�� ��� 0���� ����
                        inst.index = inst.index + 1 > inst.from.Count - 1 ? 0 : ++inst.index;
                    }

                    callback?.Invoke();
                }
                
                /// <summary>
                /// prev Ű�� ���ȴٸ� �������� �̵�
                /// </summary>
                /// <param name="callback"></param>
                static public void MovePrev(CallBack callback = null)
                {
                    if (UnityEngine.Input.GetKeyDown(inst.prev))
                    {
                        // �ε����� 0 ���� �۾��� ��� ������ ������Ʈ ����Ʈ ������ �ε��� ������ ����
                        inst.index = inst.index - 1 < 0 ? inst.from.Count - 1 : --inst.index;
                    }

                    callback?.Invoke();
                }

                /// <summary>
                /// select Ű�� ���ȴٸ� ���� �ε����� �ش��ϴ� ��ư�� onClick �̺�Ʈ ȿ�� ȣ��
                /// </summary>
                /// <param name="callback"></param>
                static public void MoveSelect(CallBack callback = null)
                {
                    if (UnityEngine.Input.GetKeyDown(inst.select))
                    {
                        // ��ư ���� �̺�Ʈ ȣ��
                        inst.from[inst.index].onClick.Invoke();
                    }

                    callback?.Invoke();
                }

                #endregion

                #region �� ��ȯ

                /// <summary>
                /// ���õ� ��ư�� RectTransform �� ��ȯ�մϴ�.
                /// </summary>
                /// <returns>List[index]'s RectTransform</returns>
                static public UnityEngine.RectTransform GetSelectedButtonPos()
                {
                    return inst.from[inst.index].GetComponent<UnityEngine.RectTransform>();
                }

                /// <summary>
                /// ���� �ε����� ��ȯ�մϴ�.
                /// </summary>
                /// <returns>index</returns>
                static public int GetIndex()
                {
                    return inst.index;
                }



                #endregion
            }
        }

    }
}