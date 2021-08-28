using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicMagicbook : MonoBehaviour
{
    [Header("마도서 페이지들")]
    public List<GameObject> pages = new List<GameObject>(); // 맨 첫 페이지가 맨 위에 들어가야 함

    private int magicBookIdx = 0; // 페이지 넘기는 용도

    [Header("마도서")]
    public GameObject magicBook = null;

    public Button btnNext = null;
    public Button btnPrev = null;

    public Button btnEnable = null;

    private void Awake()
    {

        btnEnable.onClick.AddListener(() => magicBook.SetActive(!magicBook.activeSelf)); // 마도서 펼치거나 접음

        btnNext.onClick.AddListener(() =>
        {
            ++magicBookIdx;

            if(magicBookIdx >= pages.Count)
            {
                --magicBookIdx;
                return; // 첫 페이지
            }

            Debug.Log(magicBookIdx);

            pages[magicBookIdx - 1].SetActive(!pages[magicBookIdx - 1].activeSelf); // 열린 페이지를 닫음
            pages[magicBookIdx].SetActive(!pages[magicBookIdx].activeSelf); // 닫힌 페이지를 열음
        });

        btnPrev.onClick.AddListener(() =>
        {
            --magicBookIdx; 
            if(magicBookIdx < 0)
            {
                ++magicBookIdx;
                return; // 마지막 페이지
            }

            Debug.Log(magicBookIdx);

            pages[magicBookIdx + 1].SetActive(!pages[magicBookIdx + 1].activeSelf); // 열린 페이지를 닫음
            pages[magicBookIdx].SetActive(!pages[magicBookIdx].activeSelf); // 닫힌 페이지를 열음
        });

        for (int i = 1; i < pages.Count; ++i) // 표지 빼고 다 비활성화 상태로 돌림
        {
            pages[i].SetActive(false);
        }

        magicBook.SetActive(false);
    }


    
}
