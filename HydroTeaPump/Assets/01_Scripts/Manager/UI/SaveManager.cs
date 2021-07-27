using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    bool onMem = false; // 이미 메모리에 올라가 있는지

    private void Awake()
    {
        if (onMem) return;
        onMem = true;

        DontDestroyOnLoad(this);
    }


    /// <summary>
    /// 로드합니다.
    /// </summary>
    /// <param name="fileName">파일 이름</param>
    /// <returns>DataVO</returns>
    static public DataVO LoadSavedOption(string fileName)
    {
        string path = string.Concat(Application.persistentDataPath, fileName);
        if (!File.Exists(path))
        {
            // 파일 존제 안할 경우
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
    /// 저장합니다.
    /// </summary>
    /// <param name="vo">저장할 오브젝트의 DataVO</param>
    /// <param name="fileName">파일 이름</param>
    static public void SaveOption(DataVO vo, string fileName)
    {
        string json = JsonUtility.ToJson(vo); // 직렬화
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
