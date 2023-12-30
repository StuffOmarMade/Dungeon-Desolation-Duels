using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void ReturnToGame()
    {
        
        SceneManager.LoadScene("multjoin");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("main menu");
    }
}
