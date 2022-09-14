using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class GameMemory : MonoBehaviour
{
    public static GameMemory Instance;
    private string _playerName;
    public string PlayerName { 
        get { 
            return _playerName; 
        }
        set { 
            _playerName = value; 
            SaveName(); 
        } 
    }
 
    public int BestPlayerScore { get; private set; } = 0;
    public bool TryUpdateBestePlayerScore(int score)
    {
        if (score > this.BestPlayerScore) { 
            this.BestPlayerScore = score;
            return true;
        }
        return false;
    }    


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
    }


    class SaveData
    {
        public string playerName;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.playerName = this._playerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            this._playerName = data.playerName;
        }
    }

}
