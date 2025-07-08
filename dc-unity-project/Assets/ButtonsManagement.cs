using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManagement : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInput;

    public void GoToWriteName()
    {
        SceneManager.LoadScene("WriteName");
    }

    public void PlayGame()
    {
        NameAndTimeLogic.Instance.playerName =
            string.IsNullOrEmpty(playerNameInput.text.Trim()) ? "Unknown" : playerNameInput.text.Trim();

        SceneManager.LoadScene("InGame");
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void GoToLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

