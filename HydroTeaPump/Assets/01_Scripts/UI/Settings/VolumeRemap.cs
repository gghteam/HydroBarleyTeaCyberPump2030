using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeRemap : MonoBehaviour
{
    [Header("슬라이더")]
    [SerializeField] private Slider slider = null;

    [Header("이팩트 설정인 경우")]
    [SerializeField] bool isEffect = false;

    void Start()
    {
        slider.maxValue = 1;
        slider.minValue = 0;

        if(isEffect)
        {
            slider.value = OptionManager.GetSettings().effectVolume;
        }    
        else
        {
            slider.value = OptionManager.GetSettings().musicVolume;
        }
    }

    void Update()
    {
        OptionManager.SetVolume(isEffect, slider.value);
    }
}
