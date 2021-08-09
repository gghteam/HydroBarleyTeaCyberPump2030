using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WinTween.Position;
using WinTween.Scale;

public class RhythmWindow : MonoBehaviour
{
    [SerializeField] private PuzzlePlayerInput input = null;

    [SerializeField] private float bounceDuration;
    [SerializeField] private float bounceAmount;

    private void Start()
    {
        PositionEffects.Middle(0, true);
        ScaleEffects.ToWindowed(1280, 720, 0, true);
    }

    void Update()
    {
        //bounceDuration = (float)NoteManager.GetBPM() / 1000.0f;
        bounceDuration = 0;

        if (input.up)
        {
            PositionEffects.Middle(0, true);
            PositionEffects.BounceUp(bounceDuration, bounceAmount);
        }
        if (input.down)
        {
            PositionEffects.Middle(0, true);
            PositionEffects.BounceDown(bounceDuration, bounceAmount);
        }
        if (input.left)
        {
            PositionEffects.Middle(0, true);
            PositionEffects.BounceLeft(bounceDuration, bounceAmount);
        }
        if (input.right)
        {
            PositionEffects.Middle(0, true);
            PositionEffects.BounceRight(bounceDuration, bounceAmount);
        }
    }



}
