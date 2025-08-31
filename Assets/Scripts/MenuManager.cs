using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Canvas menuCanvas; // assign your Menu Canvas in Inspector

    public void PlayGame()
    {
        // int currentScene = SceneManager.GetActiveScene().buildIndex;                            // in case menu paused time
        SceneManager.LoadScene("Main");
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene("Challenge0");
    }

    public void AboutButton()
    {
        SceneManager.LoadScene("About us");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }
}
