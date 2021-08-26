using System.Collections;
using UnityEngine;
#if UNITY_STANDALONE_WIN || !UNITY_EDITOR_LINUX

using WinTween.Position;
using WinTween.Scale;


public class WindowEffects : MonoBehaviour
{
    private void Awake()
    {
        gameObject.AddComponent<PositionEffects>();
        gameObject.AddComponent<ScaleEffects>();
    }
}

namespace WinTween
{
    /*
    Pre-maded effects for your convenience

    Have fun :3
    */

    namespace Position
    { 
        public class PositionEffects : WindowCore
        {
            static private PositionEffects   inst = null; // static ���� �뵵 
                   private WaitForEndOfFrame wait = new WaitForEndOfFrame();

            protected override void Awake()
            {
                base.Awake();

                inst = this;
            }



            #region Bounce Effects

            /// <summary>
            /// â�� ���� �ٿ�Ǵ� ȿ���� ����մϴ�.
            /// </summary>
            /// <param name="duration">�ٿ �Ⱓ</param>
            /// <param name="amount">�ٿ �� �Ÿ�</param>
            /// <param name="callback"></param>
            /// <returns></returns>
            static public void BounceUp(float duration, float amount, WindowCallBack callback = null)
            {
                inst.StartCoroutine(inst.UpBounce(duration, amount, callback));
            }
            private IEnumerator UpBounce(float duration, float amount, WindowCallBack callback = null)
            {
                Vector2Int pos = GetLocation(); // ���� â ��ġ�� ������
                float degree   = 0.0f; // �ﰢ�Լ� ��
                float add      = Mathf.PI / duration; // �ð� ���� ������ ����

                while (degree < Mathf.PI)
                {
                    degree += add * Time.deltaTime;
                    SetLocation(pos.x, pos.y - (int)(Mathf.Sin(degree) * amount)); // TODO : ��ġ
                    yield return wait;
                }

                callback?.Invoke();
            }

            /// <summary>
            /// â�� �Ʒ��� �ٿ�Ǵ� ȿ���� ����մϴ�.
            /// </summary>
            /// <param name="duration">�ٿ �Ⱓ</param>
            /// <param name="amount">�ٿ �� �Ÿ�</param>
            /// <param name="callback"></param>
            /// <returns></returns>
            static public void BounceDown(float duration, float amount, WindowCallBack callback = null)
            {
                inst.StartCoroutine(inst.DownBounce(duration, amount, callback));
            }
            private IEnumerator DownBounce(float duration, float amount, WindowCallBack callback = null)
            {
                Vector2Int pos = GetLocation();
                float degree   = 0.0f; // �ﰢ�Լ� ��
                float add      = Mathf.PI / duration; // �ð� ���� ������ ����

                while (degree < Mathf.PI)
                {
                    degree += add * Time.deltaTime;
                    SetLocation(pos.x, pos.y + (int)(Mathf.Sin(degree) * amount));
                    yield return wait;
                }

                callback?.Invoke();
            }

            /// <summary>
            /// â�� ���������� �ٿ�Ǵ� ȿ���� ����մϴ�.
            /// </summary>
            /// <param name="duration">�ٿ �Ⱓ</param>
            /// <param name="amount">�ٿ �� �Ÿ�</param>
            /// <param name="callback"></param>
            /// <returns></returns>
            static public void BounceRight(float duration, float amount, WindowCallBack callback = null)
            {
                inst.StartCoroutine(inst.RightBounce(duration, amount, callback));
            }
            private IEnumerator RightBounce(float duration, float amount, WindowCallBack callback = null)
            {
                Vector2Int pos = GetLocation();
                float degree   = 0.0f; // �ﰢ�Լ� ��
                float add      = Mathf.PI / duration; // �ð� ���� ������ ����

                while (degree < Mathf.PI)
                {
                    degree += add * Time.deltaTime;
                    SetLocation(pos.x + (int)(Mathf.Sin(degree) * amount), pos.y);
                    yield return wait;
                }

                callback?.Invoke();
            }

            /// <summary>
            /// â�� �������� �ٿ�Ǵ� ȿ���� ����մϴ�.
            /// </summary>
            /// <param name="duration">�ٿ �Ⱓ</param>
            /// <param name="amount">�ٿ �� �Ÿ�</param>
            /// <param name="callback"></param>
            /// <returns></returns>
            static public void BounceLeft(float duration, float amount, WindowCallBack callback = null)
            {
                inst.StartCoroutine(inst.LeftBounce(duration, amount, callback));
            }
            private IEnumerator LeftBounce(float duration, float amount, WindowCallBack callback = null)
            {
                Vector2Int pos = GetLocation();
                float degree   = 0.0f; // �ﰢ�Լ� ��
                float add      = Mathf.PI / duration; // �ð� ���� ������ ����
                
                while (degree < Mathf.PI)
                {
                    degree += add * Time.deltaTime;
                    SetLocation(pos.x - (int)(Mathf.Sin(degree) * amount), pos.y);
                    yield return wait;
                }

                callback?.Invoke();
            }

            #endregion // Bounce Effects

            #region Shake Effects

            /// <summary>
            /// â�� �¿�� ���ϴ�.
            /// </summary>
            /// <param name="duration">��� �Ⱓ</param>
            /// <param name="amount">��� �Ÿ�</param>
            /// <param name="count">��� Ƚ��</param>
            /// <param name="callBack"></param>
            static public void ShakeX(float duration, float amount, int count, WindowCallBack callBack = null)
            {
                if (count == 0) return;
                inst.StartCoroutine(inst.XShake(duration, amount, count, callBack));
            }
            private IEnumerator XShake(float duration, float amount, int count, WindowCallBack callBack = null)
            {
                count *= 2;

                Vector2Int pos = GetLocation();

                float degree = 0.0f; // �ﰢ�Լ� ��
                float add = Mathf.PI / duration; // �ð� ���� ������ ����

                for (int i = 0; i < count; ++i)
                {
                    degree = 0.0f;

                    while (degree < Mathf.PI)
                    {
                        degree += add;

                        if (i % 2 == 0)
                        {
                            SetLocation(pos.x + (int)(Mathf.Sin(degree) * amount), pos.y);
                        }
                        else
                        {
                            SetLocation(pos.x - (int)(Mathf.Sin(degree) * amount), pos.y);
                        }
                        yield return wait;
                    }
                }

                Middle(0, true);
            }

            /// <summary>
            /// â�� ���Ϸ� ���ϴ�.
            /// </summary>
            /// <param name="duration">��� �Ⱓ</param>
            /// <param name="amount">��� �Ÿ�</param>
            /// <param name="count">��� Ƚ��</param>
            /// <param name="callBack"></param>
            static public void ShakeY(float duration, float amount, int count, WindowCallBack callBack = null)
            {
                if (count == 0) return;
                inst.StartCoroutine(inst.YShake(duration, amount, count, callBack));
            }
            private IEnumerator YShake(float duration, float amount, int count, WindowCallBack callBack = null)
            {
                count *= 2;

                Vector2Int pos = GetLocation();

                float degree = 0.0f; // �ﰢ�Լ� ��
                float add = Mathf.PI / duration; // �ð� ���� ������ ����

                for (int i = 0; i < count; ++i)
                {
                    degree = 0.0f;

                    while (degree < Mathf.PI)
                    {
                        degree += add;

                        if (i % 2 == 0)
                        {
                            SetLocation(pos.x, pos.y + (int)(Mathf.Sin(degree) * amount));
                        }
                        else
                        {
                            SetLocation(pos.x, pos.y - (int)(Mathf.Sin(degree) * amount));
                        }
                        yield return wait;
                    }
                }

                Middle(0, true);
            }


            #endregion // Shake Effects
        }
    }

    namespace Scale
    {
        public class ScaleEffects : WindowCore
        {
            static private ScaleEffects      inst = null; // static ���� �뵵
                   private WaitForEndOfFrame wait = new WaitForEndOfFrame();

            protected override void Awake()
            {
                base.Awake();

                inst = this;
            }

            #region Window Size effects

            /// <summary>
            /// â�� ���� Ű���� ��üȭ������ ����ϴ�.
            /// </summary>
            /// <param name="duration">â Ŀ���� �Ⱓ</param>
            /// <param name="snap">���ϸ��̼� ���� �̵� ����</param>
            /// <param name="callBack"></param>
            static public void ToFullScreen(float duration, bool snap = false, WindowCallBack callBack = null)
            {
                inst.StartCoroutine(inst.FullScreen(duration, snap, callBack));
            }
            private IEnumerator FullScreen(float duration, bool snap = false, WindowCallBack callBack = null)
            {
                Vector2Int targetScale = new Vector2Int(Screen.currentResolution.width, Screen.currentResolution.height);
                Vector2Int curScale = GetCurrentSize();
                Vector2Int beginScale = curScale;

                float degree = 0.0f; // �ﰢ�Լ� ��
                float add = Mathf.PI / duration; // �ð� ���� ������ ����

                if (snap)
                {
                    Screen.SetResolution(targetScale.x, targetScale.y, true);
                    ResetPositionVar();
                    callBack?.Invoke();
                    yield break;
                }

                while (degree <= Mathf.PI / 2.0f)
                {
                    degree += add;
                    curScale.x = beginScale.x;
                    curScale.y = beginScale.y;

                    float xTemp = Mathf.Sin(degree) * (targetScale.x - beginScale.x);
                    float yTemp = Mathf.Sin(degree) * (targetScale.y - beginScale.y);

                    curScale.x += (int)xTemp;
                    curScale.y += (int)yTemp;

                    SetWindowSize(curScale);
                    ResetPositionVar();
                    Middle(0, true);
                    yield return wait;
                }

                Screen.SetResolution(targetScale.x, targetScale.y, true);
                callBack?.Invoke();
            }

            #region Windowed Caller Function
            /// <summary>
            /// ��üȭ���� ������ �� â�� ���� ���Դϴ�.
            /// </summary>
            /// <param name="targetScale">��ǥ ������</param>
            /// <param name="duration">â �پ��� �Ⱓ</param>
            /// <param name="snap">���ϸ��̼� ���� �̵� ����</param>
            /// <param name="callBack"></param>
            static public void ToWindowed(Vector2Int targetScale, float duration, bool snap = false, WindowCallBack callBack = null)
            {
                inst.StartCoroutine(inst.Windowed(targetScale.x, targetScale.y, duration, snap, callBack));
            }
            /// <summary>
            /// ��üȭ���� ������ �� â�� ���� ���Դϴ�.
            /// </summary>
            /// <param name="targetX">��ǥ X ������</param>
            /// <param name="targetY">���� Y ������</param>
            /// <param name="duration">â �پ��� �Ⱓ</param>
            /// <param name="snap">���ϸ��̼� ���� �̵� ����</param>
            /// <param name="callBack"></param>
            static public void ToWindowed(int targetX, int targetY, float duration, bool snap = false, WindowCallBack callBack = null)
            {
                inst.StartCoroutine(inst.Windowed(targetX, targetY, duration, snap, callBack));
            }
            #endregion

            private IEnumerator Windowed(int targetX, int targetY, float duration, bool snap = false, WindowCallBack callBack = null)
            {
                Vector2Int curScale = GetCurrentSize();
                Resolution curRes = Screen.currentResolution;

                float degree = 0.0f; // �ﰢ�Լ� ��
                float add = Mathf.PI / duration; // �ð� ���� ������ ����

                Screen.SetResolution(curScale.x, curScale.y, false);
                if (snap)
                {
                    SetWindowSize(targetX, targetY);
                    ResetPositionVar();
                    Middle(0, true);
                    callBack?.Invoke();
                    yield break;
                }


                while (degree <= Mathf.PI / 2.0f)
                {
                    degree += add;
                    curScale.x = targetX;
                    curScale.y = targetY;

                    float xTemp = Mathf.Cos(degree) * (curRes.width - targetX);
                    float yTemp = Mathf.Cos(degree) * (curRes.height - targetY);

                    curScale.x += (int)xTemp;
                    curScale.y += (int)yTemp;

                    SetWindowSize(curScale);
                    ResetPositionVar();
                    Middle(0, true);
                    yield return wait;
                }


                SetWindowSize(targetX, targetY);
                ResetPositionVar();
                Middle(0, true);
                callBack?.Invoke();
            }

            #endregion // Window Size effects



            /// <summary>
            /// Ư���� ��ġ�� â�� �����Դϴ�.
            /// </summary>
            /// <param name="pos">�̵���ų ��ġ</param>
            /// <param name="duration">�̵� �Ⱓ</param>
            /// <param name="snap">���Ͽ��̼� ���� �̵� ����</param>
            /// <returns></returns>
            public IEnumerator MoveWindow(Vector2Int pos, float duration, bool snap = false)
            {
                if (snap)
                {
                    SetLocation(pos);
                    yield break;
                }

                float degree = 0.0f; // �ﰢ�Լ� ��
                float add = Mathf.PI / duration; // �ð� ���� ������ ����

                while (degree < Mathf.PI / 2.0f)
                {
                    degree += add;
                    SetLocation(pos.x, pos.y); // TODO : snap �̶� �ٸ��� ����
                    yield return wait;
                }
            }

            // TODO : Dotween ó�� �ڿ� SetEase ���̰� ����
        }
    }
}

#endif