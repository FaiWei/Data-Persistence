using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InfoManager : MonoBehaviour
{
    public static InfoManager Instance;
    public int bestScore;
    public string leaderScore;
    public string currentPlayer;
    public string lastPlayer;
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string leaderScore;
        public string lastPlayer;
    }
    public void ResetSave()
    {
        SaveData data = new SaveData();
        data.bestScore = 0;
        data.leaderScore = "None";
        data.lastPlayer = "";
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void Save()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.leaderScore = leaderScore;
        data.lastPlayer = currentPlayer;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            leaderScore = data.leaderScore;
            lastPlayer = data.lastPlayer;
        }
    }

}
