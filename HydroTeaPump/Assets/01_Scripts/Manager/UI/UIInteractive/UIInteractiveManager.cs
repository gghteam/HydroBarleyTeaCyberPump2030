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
            /// 방향키로 선택하는 기능을 가진 클레스
            /// </summary>
            public class Select
            {
                static private Select inst;                        // static 접근 용도
                       private int    index;                       // 현제 인덱스
                       private List<UnityEngine.UI.Button> from;   // 선택할 버튼들 TODO : Dictionary<int index, Button button> 으로 바꾸면 어떨까.
                       private UnityEngine.KeyCode next;           // 다음 버튼으로 이동
                       private UnityEngine.KeyCode prev;           // 이전 버튼으로 이동
                       private UnityEngine.KeyCode select;         // 이전 버튼으로 이동


                /// <summary>
                /// 방향키로 선택하는 기능을 가진 클래스
                /// </summary>
                /// <param name="next">다음 버튼</param>
                /// <param name="prev">이전 버튼</param>
                public Select()
                {
                    from = new List<UnityEngine.UI.Button>();
                    inst = this;
                }

                #region 초기화

                /// <summary>
                /// 선택할 버튼들을 추가합니다.
                /// </summary>
                /// <param name="selectFrom">선택할 버튼들</param>
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
                /// 선택할 버튼들을 추가합니다.
                /// </summary>
                /// <param name="selectFrom">선택할 버튼들</param>
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
                /// 이동 키 설정
                /// </summary>
                /// <param name="next">다음 버튼 이동</param>
                /// <param name="prev">이전 버튼 이동</param>
                static public void SetKey(UnityEngine.KeyCode next, UnityEngine.KeyCode prev, UnityEngine.KeyCode select, CallBack callback = null)
                {
                    inst.next   = next;
                    inst.prev   = prev;
                    inst.select = select;

                    callback?.Invoke();
                }

                #endregion

                #region 수정

                /// <summary>
                /// 선택할 버튼을 하나 추가합니다.
                /// </summary>
                /// <param name="selectFrom">선택할 버튼</param>
                /// <param name="callback"></param>
                static public void AddFrom(UnityEngine.UI.Button selectFrom, CallBack callback = null)
                {
                    inst.from.Add(selectFrom);

                    callback?.Invoke();
                }

                /// <summary>
                /// 선택할 버튼 리스트를 초기화합니다.
                /// </summary>
                /// <param name="callback"></param>
                static public void Reset(CallBack callback = null)
                {
                    inst.from.Clear();

                    callback?.Invoke();
                }

                #endregion

                #region 이동

                /// <summary>
                /// next 키가 눌렸다면 다음으로 이동
                /// </summary>
                /// <param name="callback"></param>
                static public void MoveNext(CallBack callback = null)
                {
                    if (UnityEngine.Input.GetKeyDown(inst.next))
                    {
                        // 선택할 오브젝트 리스트 마지막 인덱스보다 인덱스카 커질 경우 0으로 변경
                        inst.index = inst.index + 1 > inst.from.Count - 1 ? 0 : ++inst.index;
                    }

                    callback?.Invoke();
                }
                
                /// <summary>
                /// prev 키가 눌렸다면 이전으로 이동
                /// </summary>
                /// <param name="callback"></param>
                static public void MovePrev(CallBack callback = null)
                {
                    if (UnityEngine.Input.GetKeyDown(inst.prev))
                    {
                        // 인덱스가 0 보다 작아질 경우 선택할 오브젝트 리스트 마지막 인덱스 값으로 변경
                        inst.index = inst.index - 1 < 0 ? inst.from.Count - 1 : --inst.index;
                    }

                    callback?.Invoke();
                }

                /// <summary>
                /// select 키가 눌렸다면 현제 인덱스에 해당하는 버튼의 onClick 이벤트 효과 호출
                /// </summary>
                /// <param name="callback"></param>
                static public void MoveSelect(CallBack callback = null)
                {
                    if (UnityEngine.Input.GetKeyDown(inst.select))
                    {
                        // 버튼 눌림 이벤트 호출
                        inst.from[inst.index].onClick.Invoke();
                    }

                    callback?.Invoke();
                }

                #endregion

                #region 값 반환

                /// <summary>
                /// 선택된 버튼의 RectTransform 을 반환합니다.
                /// </summary>
                /// <returns>List[index]'s RectTransform</returns>
                static public UnityEngine.RectTransform GetSelectedButtonPos()
                {
                    return inst.from[inst.index].GetComponent<UnityEngine.RectTransform>();
                }

                /// <summary>
                /// 현제 인덱스를 반환합니다.
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