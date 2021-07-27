using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    bool onMem = false; // �̹� �޸𸮿� �ö� �ִ���

    private void Awake()
    {
        if (onMem) return;
        onMem = true;

        DontDestroyOnLoad(this);
    }


    /// <summary>
    /// �ε��մϴ�.
    /// </summary>
    /// <param name="fileName">���� �̸�</param>
    /// <returns>DataVO</returns>
    static public DataVO LoadSavedOption(string fileName)
    {
        string path = string.Concat(Application.persistentDataPath, fileName);
        if (!File.Exists(path))
        {
            // ���� ���� ���� ���
            return null;
        }

        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);

        DataVO vo = JsonUtility.FromJson<DataVO>(sr.ReadToEnd());

        sr.Close();
        fs.Close();

        Debug.Log("Data loaded");

        return vo;
    }

    /// <summary>
    /// �����մϴ�.
    /// </summary>
    /// <param name="vo">������ ������Ʈ�� DataVO</param>
    /// <param name="fileName">���� �̸�</param>
    static public void SaveOption(DataVO vo, string fileName)
    {
        string json = JsonUtility.ToJson(vo); // ����ȭ
        string path = string.Concat(Application.persistentDataPath, fileName);

        File.WriteAllText(path, string.Empty);

        FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);


        sw.WriteLine(json);
        Debug.Log($"Data saved.\r\nPath: {path}");

        sw.Close();
        fs.Close();
    }
}
