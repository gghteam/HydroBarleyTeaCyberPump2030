using System;
using UnityEngine;

// ���� ���� ����

[Serializable]
public class SettingsVO
{
    // Ű �Է�
    public KeyCode moveUp;
    public KeyCode moveDown;
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode select;

    // �Ҹ�
    public float effectVolume;
    public float musicVolume;

    public SettingsVO(KeyCode moveUp, KeyCode moveDown, KeyCode moveLeft, KeyCode moveRight, KeyCode select, float effectVolume, float musicVolume)
    {
        this.moveUp    = moveUp;
        this.moveDown  = moveDown;
        this.moveLeft  = moveLeft;
        this.moveRight = moveRight;
        this.select    = select;

        this.effectVolume = effectVolume;
        this.musicVolume  = musicVolume;
    }

    public SettingsVO() { }
    
    public SettingsVO(SettingsVO vo)
    {
        moveUp    = vo.moveUp;
        moveDown  = vo.moveDown;
        moveLeft  = vo.moveLeft;
        moveRight = vo.moveRight;
        select    = vo.select;

        effectVolume = vo.effectVolume;
        musicVolume  = vo.musicVolume;
    }
}