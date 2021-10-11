using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public string heighScoreName;
    public string activePlayerName;
    public int heighScore = 0;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    [SerializeField]
    class SateData
    {
        public string scoreNameData;
        public int scoreData;
    }

    public void SaveDate()
    {
        SateData data = new SateData();
        data.scoreNameData = heighScoreName;
        data.scoreData = heighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SateData data = JsonUtility.FromJson<SateData>(json);

            heighScoreName = data.scoreNameData;
            heighScore = data.scoreData;

        }
    }
}
