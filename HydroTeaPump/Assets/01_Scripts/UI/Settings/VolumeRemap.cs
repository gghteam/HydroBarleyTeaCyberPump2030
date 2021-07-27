using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeRemap : MonoBehaviour
{
    [Header("�����̴�")]
    [SerializeField] private Slider slider = null;

    [Header("����Ʈ ������ ���")]
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
