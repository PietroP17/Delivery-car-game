using UnityEngine;
using System.IO;

public class NameAndTimeLogic : MonoBehaviour
{
    public static NameAndTimeLogic Instance;

    public string playerName;
    public float completionTime;

    public ScoreList leaderboard = new ScoreList();

    private string savePath;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Application.persistentDataPath + "/leaderboard.json";
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private ScoreList LoadScores()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<ScoreList>(json);
        }
        else
        {
            return new ScoreList();
        }
    }

    public void SaveScore()
    {
        leaderboard = LoadScores();
        leaderboard.leaderboard.Add(new ScoreItem(playerName, completionTime));
        leaderboard.leaderboard.Sort((a, b) => a.time.CompareTo(b.time));

        string json = JsonUtility.ToJson(leaderboard, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Punteggio salvato: " + savePath);
    }
}