using System.IO;
using TMPro;
using UnityEngine;

public class LeaderboardFromMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI leaderboardText;

    void Awake()
    {
        string path = Application.persistentDataPath + "/leaderboard.json";

        if (!File.Exists(path))
        {
            leaderboardText.text = "Nessun record disponibile.";
            return;
        }

        string json = File.ReadAllText(path);
        ScoreList leaderboardContainer = JsonUtility.FromJson<ScoreList>(json);

        if (leaderboardContainer == null ||
            leaderboardContainer.leaderboard == null ||
            leaderboardContainer.leaderboard.Count == 0)
        {
            leaderboardText.text = "Nessun record disponibile.";
            return;
        }

        string leaderboardDisplay = "";

        for (int i = 0; i < Mathf.Min(5, leaderboardContainer.leaderboard.Count); i++)
        {
            string name = leaderboardContainer.leaderboard[i].name;
            float time = leaderboardContainer.leaderboard[i].time;
            int min = Mathf.FloorToInt(time / 60f);
            int sec = Mathf.FloorToInt(time % 60f);
            string formatted = string.Format("{0:00}:{1:00}", min, sec);
            leaderboardDisplay += $"{i + 1}. {name} - {formatted}\n\n";
        }

        leaderboardText.text = leaderboardDisplay; 
    }
}
