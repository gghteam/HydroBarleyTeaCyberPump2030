using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    //싱글톤====================
    static GameObject _container;
    static GameObject Container
    {
        get
        {
            return _container;
        }
    }
    static GameSave _instance;
    public static GameSave Instance
    {
        get
        {
            if (!_instance)
            {
                _container = new GameObject();
                _container.name = "SaveGame";
                _instance = _container.AddComponent(typeof(GameSave)) as GameSave;
                DontDestroyOnLoad(_container);
            }
            return _instance;
        }
    }
    // =================================================
    public string GameDataFileName = ".json";

    private string filePath = "";


    private SaveData _data;

    public SaveData data
    {
        get
        {
            if (_data == null)
            {
                LoadGameData();
                SaveGameData();
            }
            return _data;
        }
    }
    private void Awake()
    {
        filePath = string.Concat(Application.persistentDataPath, GameDataFileName);
        Debug.Log(filePath);
    }

    /// <summary>
    /// 데이터 로드 함수, 데이터가 없을경우 새로운 파일 생성
    /// </summary>
    public void LoadGameData()
    {
        if (File.Exists(filePath))
        {
            Debug.Log("불러오기");
            string FromJsonData = File.ReadAllText(filePath);

            _data = JsonUtility.FromJson<SaveData>(FromJsonData);
        }
        else
        {
            Debug.Log("새로운 파일 생성");
            _data = new SaveData();
        }

    }

    /// <summary>
    /// 데이터 저장 함수
    /// </summary>
    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(data, true);
        Debug.Log("저장완료");

        File.WriteAllText(filePath, ToJsonData);
    }
}
