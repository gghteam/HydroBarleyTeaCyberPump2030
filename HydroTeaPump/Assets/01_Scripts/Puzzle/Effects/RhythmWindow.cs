using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_STANDALONE_WIN || !UNITY_EDITOR_LINUX

using WinTween.Position;
using WinTween.Scale;

public class RhythmWindow : MonoBehaviour
{
    [SerializeField] private PuzzlePlayerInput input = null;

    private float bounceDuration = 0.05f;
    private float bounceAmount = 15.0f;

    private void Start()
    {
        PositionEffects.Middle(0, true);
        ScaleEffects.ToWindowed(1600, 900, 0, true);
    }

    void Update()
    {
        //bounceDuration = (float)NoteManager.GetBPM() / 1000.0f;

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

#endif