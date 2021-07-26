using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    //�̱���====================
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
    /// ������ �ε� �Լ�, �����Ͱ� ������� ���ο� ���� ����
    /// </summary>
    public void LoadGameData()
    {
        if (File.Exists(filePath))
        {
            Debug.Log("�ҷ�����");
            string FromJsonData = File.ReadAllText(filePath);

            _data = JsonUtility.FromJson<SaveData>(FromJsonData);
        }
        else
        {
            Debug.Log("���ο� ���� ����");
            _data = new SaveData();
        }

    }

    /// <summary>
    /// ������ ���� �Լ�
    /// </summary>
    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(data, true);
        Debug.Log("����Ϸ�");

        File.WriteAllText(filePath, ToJsonData);
    }
}
