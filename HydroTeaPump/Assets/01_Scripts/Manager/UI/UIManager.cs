using UIManagement.Button;
using UIManagement.Slider;

public class UIManager : UnityEngine.MonoBehaviour
{
    private void Awake()
    {
        new ButtonManagement();
        new SliderManagement();

        DontDestroyOnLoad(this);
    }
}



namespace UIManagement
{
    // callback delegate
    public delegate void CallBack();

    namespace Button
    {
        using UnityEngine.Events;

        public class ButtonManagement
        {
            #region 기능

            /// <summary>
            /// 버튼에 기능을 추가합니다.
            /// </summary>
            /// <param name="btn">추가할 버튼</param>
            /// <param name="function">추가할 기능</param>
            /// <param name="callback"></param>
            static public void AddEvent(UnityEngine.UI.Button btn, UnityAction function, CallBack callback = null)
            {
                btn.onClick.AddListener(function);

                callback?.Invoke();
            }

            /// <summary>
            /// 버튼에 달린 기능들을 전부 제거합니다.
            /// </summary>
            /// <param name="btn">제거할 버튼</param>
            /// <param name="callback"></param>
            static public void ResetEvent(UnityEngine.UI.Button btn, CallBack callback = null)
            {
                btn.onClick.RemoveAllListeners();

                callback?.Invoke();
            }

            #endregion

            #region 상태

            /// <summary>
            /// 버튼을 활성화시킵니다.
            /// </summary>
            /// <param name="btn">활성화 시킬 버튼</param>
            /// <param name="callback"></param>
            static public void EnableButton(UnityEngine.UI.Button btn, CallBack callback = null)
            {
                btn.interactable = true;

                callback?.Invoke();
            }

            /// <summary>
            /// 버튼을 비활성화시킵니다.
            /// </summary>
            /// <param name="btn">비활성화 시킬 버튼</param>
            /// <param name="callback"></param>
            static public void DisableButton(UnityEngine.UI.Button btn, CallBack callback = null)
            {
                btn.interactable = false;

                callback?.Invoke();
            }

            #endregion

            #region 이미지

            /// <summary>
            /// 버튼의 이미지를 변경합니다.
            /// </summary>
            /// <param name="btn">변경할 버튼</param>
            /// <param name="sprite">변경할 이미지</param>
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
            #region 값

            /// <summary>
            /// 슬라이더의 초기값을 설정합니다.
            /// </summary>
            /// <param name="slider">값을 설정할 슬라이더</param>
            /// <param name="minValue">최소값</param>
            /// <param name="maxValue">최대값</param>
            /// <param name="value">초기값</param>
            /// <param name="callback"></param>
            static public void SetBaseValue(UnityEngine.UI.Slider slider, float minValue, float maxValue, float value, CallBack callback = null)
            {
                slider.maxValue = maxValue;
                slider.minValue = minValue;
                slider.value = value;

                callback?.Invoke();
            }

            /// <summary>
            /// 슬라이더에 값을 입력합니다.<br></br>
            /// </summary>
            /// <param name="slider">값을 넣을 슬라이더</param>
            /// <param name="value">값</param>
            /// <param name="clamp">최대값 이상으로 들어갈 시 알아서 잘라줄 지 여부</param>
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
            /// 슬라이더에 값을 더합니다.
            /// </summary>
            /// <param name="slider">값을 더할 슬라이더</param>
            /// <param name="value">값</param>
            /// <param name="clamp">최대값 이상으로 더해질 시 알아서 잘라줄 지 여부</param>
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
            /// 슬라이더에 값을 뺍니다.
            /// </summary>
            /// <param name="slider">값을 뺄 슬라이더</param>
            /// <param name="value">값</param>
            /// <param name="clamp">최소값 이하로 빼질 시 알아서 잘라줄 지 여부</param>
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
    }}
