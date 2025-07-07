using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("In game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

