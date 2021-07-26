using UI.Management.Button;
using UI.Management.Slider;
using UI.Management.Pannel;

public class UIManager : UnityEngine.MonoBehaviour
{
    private void Awake()
    {
        new ButtonManagement();
        new SliderManagement();
        new PannelManagement();


        DontDestroyOnLoad(this);
    }
}

namespace UI
{
    // callback delegate
    public delegate void CallBack();


    namespace Management
    {

        namespace Button
        {
            using UnityEngine.Events;

            public class ButtonManagement
            {
                #region ���

                /// <summary>
                /// ��ư�� ����� �߰��մϴ�.
                /// </summary>
                /// <param name="btn">�߰��� ��ư</param>
                /// <param name="function">�߰��� ���</param>
                /// <param name="callback"></param>
                static public void AddEvent(UnityEngine.UI.Button btn, UnityAction function, CallBack callback = null)
                {
                    btn.onClick.AddListener(function);

                    callback?.Invoke();
                }

                /// <summary>
                /// ��ư�� ����� �߰��մϴ�.<br></br>
                /// �迭 ũ�Ⱑ ���ƾ� �ؿ�.
                /// </summary>
                /// <param name="btns">�߰��� ��ư�� (�迭)</param>
                /// <param name="functions">�߰��� ��ɵ� (�迭)</param>
                /// <param name="callback"></param>
                static public void AddEvent(UnityEngine.UI.Button[] btns, UnityAction[] functions, CallBack callback = null)
                {
                    if (btns.Length != functions.Length)
                    {
                        UnityEngine.Debug.LogError($"ButtonManagement: cannot link functions to buttons.\r\nReason: different array size.\r\nbuttons: {btns.Length}, functions: {functions.Length}");
                        return;
                    }

                    for (int i = 0; i < 10; ++i)
                    {
                        btns[i].onClick.AddListener(functions[i]);
                    }

                    callback?.Invoke();
                }
                
                /// <summary>
                /// ��ư�� ����� �߰��մϴ�.<br></br>
                /// ����Ʈ ũ�Ⱑ ���ƾ� �ؿ�.
                /// </summary>
                /// <param name="btns">�߰��� ��ư�� (����Ʈ)</param>
                /// <param name="functions">�߰��� ��ɵ� (����Ʈ)</param>
                /// <param name="callback"></param>
                static public void AddEvent(System.Collections.Generic.List<UnityEngine.UI.Button> btns, System.Collections.Generic.List<UnityAction> functions, CallBack callback = null)
                {
                    if (btns.Count != functions.Count)
                    {
                        UnityEngine.Debug.LogError($"ButtonManagement: cannot link functions to buttons.\r\nReason: different array size.\r\nbuttons: {btns.Count}, functions: {functions.Count}");
                        return;
                    }

                    for (int i = 0; i < 10; ++i)
                    {
                        btns[i].onClick.AddListener(functions[i]);
                    }

                    callback?.Invoke();
                }

                /// <summary>
                /// ��ư�� �޸� ��ɵ��� ���� �����մϴ�.
                /// </summary>
                /// <param name="btn">������ ��ư</param>
                /// <param name="callback"></param>
                static public void ResetEvent(UnityEngine.UI.Button btn, CallBack callback = null)
                {
                    btn.onClick.RemoveAllListeners();

                    callback?.Invoke();
                }

                #endregion

                #region ����

                /// <summary>
                /// ��ư�� Ȱ��ȭ��ŵ�ϴ�.
                /// </summary>
                /// <param name="btn">Ȱ��ȭ ��ų ��ư</param>
                /// <param name="callback"></param>
                static public void EnableButton(UnityEngine.UI.Button btn, CallBack callback = null)
                {
                    btn.interactable = true;

                    callback?.Invoke();
                }

                /// <summary>
                /// ��ư�� ��Ȱ��ȭ��ŵ�ϴ�.
                /// </summary>
                /// <param name="btn">��Ȱ��ȭ ��ų ��ư</param>
                /// <param name="callback"></param>
                static public void DisableButton(UnityEngine.UI.Button btn, CallBack callback = null)
                {
                    btn.interactable = false;

                    callback?.Invoke();
                }

                #endregion

                #region �̹���

                /// <summary>
                /// ��ư�� �̹����� �����մϴ�.
                /// </summary>
                /// <param name="btn">������ ��ư</param>
                /// <param name="sprite">������ �̹���</param>
                /// <param name="callback"></param>
                static public void SetImage(UnityEngine.UI.Button btn, UnityEngine.Sprite sprite, CallBack callback = null)
                {
                    btn.image.sprite = sprite;

                    callback?.Invoke();
                }

                #endregion
            }
        }

        namespace Slider
        {
            public class SliderManagement
            {
                #region ��

                /// <summary>
                /// �����̴��� �ʱⰪ�� �����մϴ�.
                /// </summary>
                /// <param name="slider">���� ������ �����̴�</param>
                /// <param name="minValue">�ּҰ�</param>
                /// <param name="maxValue">�ִ밪</param>
                /// <param name="value">�ʱⰪ</param>
                /// <param name="callback"></param>
                static public void SetBaseValue(UnityEngine.UI.Slider slider, float minValue, float maxValue, float value, CallBack callback = null)
                {
                    slider.maxValue = maxValue;
                    slider.minValue = minValue;
                    slider.value = value;

                    callback?.Invoke();
                }

                /// <summary>
                /// �����̴��� ���� �Է��մϴ�.<br></br>
                /// </summary>
                /// <param name="slider">���� ���� �����̴�</param>
                /// <param name="value">��</param>
                /// <param name="clamp">�ִ밪 �̻����� �� �� �˾Ƽ� �߶��� �� ����</param>
                /// <param name="callback"></param>
                static public void SetValue(UnityEngine.UI.Slider slider, float value, bool clamp = false, CallBack callback = null)
                {
                    if (clamp)
                    {
                        value = value > slider.maxValue ? slider.maxValue : value;
                    }

                    slider.value = value;

                    callback?.Invoke();
                }

                /// <summary>
                /// �����̴��� ���� ���մϴ�.
                /// </summary>
                /// <param name="slider">���� ���� �����̴�</param>
                /// <param name="value">��</param>
                /// <param name="clamp">�ִ밪 �̻����� ������ �� �˾Ƽ� �߶��� �� ����</param>
                /// <param name="callback"></param>
                static public void AddValue(UnityEngine.UI.Slider slider, float value, bool clamp = false, CallBack callback = null)
                {
                    if (clamp)
                    {
                        value = value + slider.value > slider.maxValue ? value - (value + slider.value - slider.maxValue) : value;
                    }

                    slider.value += value;

                    callback?.Invoke();
                }

                /// <summary>
                /// �����̴��� ���� ���ϴ�.
                /// </summary>
                /// <param name="slider">���� �� �����̴�</param>
                /// <param name="value">��</param>
                /// <param name="clamp">�ּҰ� ���Ϸ� ���� �� �˾Ƽ� �߶��� �� ����</param>
                /// <param name="callback"></param>
                static public void SubValue(UnityEngine.UI.Slider slider, float value, bool clamp = false, CallBack callback = null)
                {
                    if (clamp)
                    {
                        value = slider.value - value < slider.minValue ? slider.value : value;
                    }

                    slider.value -= value;

                    callback?.Invoke();
                }



                #endregion
            }
        }

        namespace Pannel
        {
            public class PannelManagement
            {
                #region Ȱ��ȭ, ��Ȱ��ȭ

                /// <summary>
                /// �г��� Ȱ��ȭ ��ŵ�ϴ�.
                /// </summary>
                /// <param name="pannel">Ȱ��ȭ ��ų �г�</param>
                /// <param name="callback"></param>
                static public void Show(UnityEngine.GameObject pannel, CallBack callback)
                {
                    pannel.SetActive(true);

                    callback?.Invoke();
                }

                /// <summary>
                /// �г��� ��Ȱ��ȭ ��ŵ�ϴ�.
                /// </summary>
                /// <param name="pannel">��Ȱ��ȭ ��ų �г�</param>
                /// <param name="callback"></param>
                static public void Hide(UnityEngine.GameObject pannel, CallBack callback)
                {
                    pannel.SetActive(false);

                    callback?.Invoke();
                }

                /// <summary>
                /// Ȱ��ȭ �� �гΰ� ��Ȱ��ȭ �� �г��� �ٲߴϴ�.
                /// </summary>
                /// <param name="enabledPannel">Ȱ��ȭ ���ִ� �г�</param>
                /// <param name="disabledPannel">��Ȱ��ȭ ���ִ� �г�</param>
                /// <param name="callback"></param>
                static public void Change(UnityEngine.GameObject enabledPannel, UnityEngine.GameObject disabledPannel, CallBack callback)
                {
                    disabledPannel.SetActive(true);
                    enabledPannel.SetActive(false);

                    callback?.Invoke();
                }

                #endregion
            }
        }
    }

}