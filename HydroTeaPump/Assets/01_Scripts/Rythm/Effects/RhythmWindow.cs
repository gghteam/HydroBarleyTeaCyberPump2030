using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WinTween.Position;

public class RhythmWindow : MonoBehaviour
{
    [SerializeField] private RhythmPlayerInput input = null;

    [SerializeField] private float bounceDuration;
    [SerializeField] private float bounceAmount;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bounceDuration = (float)NoteManager.GetBPM() / 1000.0f;

        if (input.up)
        {
            PositionEffects.BounceUp(bounceDuration, bounceAmount);
        }
        if (input.down)
        {
            PositionEffects.BounceDown(bounceDuration, bounceAmount);
        }
        if (input.left)
        {
            PositionEffects.BounceLeft(bounceDuration, bounceAmount);
        }
        if (input.right)
        {
            PositionEffects.BounceRight(bounceDuration, bounceAmount);
        }
    }



}
