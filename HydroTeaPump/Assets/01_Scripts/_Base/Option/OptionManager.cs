using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class OptionManager : MonoBehaviour
{
    static private OptionManager inst; // static 접근 용도

    private SettingsVO settingsData = new SettingsVO();

    public KeyCode up     = KeyCode.W;
    public KeyCode down   = KeyCode.S;
    public KeyCode left   = KeyCode.A;
    public KeyCode right  = KeyCode.D;
    public KeyCode select = KeyCode.Return;
    public KeyCode exit   = KeyCode.Escape;

    public float effectVolume = 0.8f;
    public float musicVolume  = 0.8f;

    private bool isInstantiated = false;

    private void Awake()
    {
        if (isInstantiated)
        {
            Destroy(this);
        }
        else
        {
            isInstantiated = true;
            inst = this;
            DontDestroyOnLoad(this);
            LoadSavedOption();
        }

        
    }

    private void OnDestroy()
    {
        SaveOption(new SettingsVO(up, down, left, right, select, exit, effectVolume, musicVolume));
    }

    /// <summary>
    /// returns setting data
    /// </summary>
    /// <returns>SettingsVO</returns>
    static public SettingsVO GetSettings()
    {
        return inst.settingsData;
    }
    
    static public KeyCode GetSettings(KeyMapEnum key)
    {
        switch (key)
        {
            case KeyMapEnum.up:     return inst.settingsData.moveUp;   
            case KeyMapEnum.down:   return inst.settingsData.moveDown; 
            case KeyMapEnum.left:   return inst.settingsData.moveLeft; 
            case KeyMapEnum.right:  return inst.settingsData.moveRight;
            case KeyMapEnum.select: return inst.settingsData.select;   
            case KeyMapEnum.esc:    return inst.settingsData.exit;     
            default: return KeyCode.None;
        }
    }

    static public void KeyRemap(KeyCode keyCode, KeyMapEnum key)
    {
        switch (key)
        {
            case KeyMapEnum.up:
                inst.up = keyCode;
                break;

            case KeyMapEnum.down:
                inst.down = keyCode;
                break;

            case KeyMapEnum.left:
                inst.left = keyCode;
                break;

            case KeyMapEnum.right:
                inst.right = keyCode;
                break;

            case KeyMapEnum.select:
                inst.select = keyCode;
                break;

            case KeyMapEnum.esc:
                inst.exit = keyCode;
                break;

            default:
                break;
        }
    }
}


// 저장, 로드
public partial class OptionManager : MonoBehaviour
{
    static public void LoadSavedOption()
    {
        string path = string.Concat(Application.persistentDataPath, "/settings.json");
        if (!File.Exists(path))
        {
            // 초기값
            inst.settingsData.moveUp    = inst.up;
            inst.settingsData.moveDown  = inst.down;
            inst.settingsData.moveLeft  = inst.left;
            inst.settingsData.moveRight = inst.right;
            inst.settingsData.select    = inst.select;
            inst.settingsData.exit      = inst.exit;

            inst.settingsData.effectVolume = inst.effectVolume;
            inst.settingsData.musicVolume  = inst.musicVolume;

            return;
        }

        FileStream   fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);

        inst.settingsData = JsonUtility.FromJson<SettingsVO>(JsonUtility.FromJson<DataVO>(sr.ReadToEnd()).payload); 

        sr.Close();
        fs.Close();

        inst.SetSettingsData();

        Debug.Log("Data loaded");
    }

    static public void SaveOption(SettingsVO vo)
    {
        string       json = JsonUtility.ToJson(new DataVO("option", JsonUtility.ToJson(vo))); // 직렬화
        string       path = string.Concat(Application.persistentDataPath, "/settings.json");
        
        File.WriteAllText(path, string.Empty);

        FileStream   fs   = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
        StreamWriter sw   = new StreamWriter(fs);


        sw.WriteLine(json);
        //Debug.Log($"Data saved.\r\nPath: {path}");

        sw.Close();
        fs.Close();
    }

    private void SetSettingsData()
    {
        up     = settingsData.moveUp;
        down   = settingsData.moveDown;
        left   = settingsData.moveLeft;
        right  = settingsData.moveRight;
        select = settingsData.select;
        exit   = settingsData.exit;

        effectVolume = settingsData.effectVolume;
        musicVolume  = settingsData.musicVolume;
    }

    /// <summary>
    /// 볼륨을 설정합니다.
    /// </summary>
    /// <param name="isEffect"></param>
    /// <param name="value"></param>
    static public void SetVolume(bool isEffect, float value)
    {
        if (isEffect)
        {
            inst.effectVolume = value;
        }
        else
        {
            inst.musicVolume = value;
        }
    }
}