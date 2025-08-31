using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text botsText;
    [SerializeField] GameObject victoryText;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject againButton;
    [SerializeField] GameObject menuButton;

    int botsLeft = 0;
    void Start()
    {
        // starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
    }

    public void BotsLeft(int amount)
    {
        botsLeft += amount;
        botsText.text = "Enemies: " + botsLeft.ToString();
        if (botsLeft <= 0)
        {
            victoryText.SetActive(true);
            StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
            starterAssetsInputs.SetCursorState(false);
            nextButton.SetActive(true);
            againButton.SetActive(true);
            menuButton.SetActive(true);
        }
    }
    public void RestartButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Main" + currentScene);
        // starterAssetsInputs.SetCursorState(true);
        SceneManager.LoadScene(currentScene);
    }
    public void MenuButton()
    {
        
        SceneManager.LoadScene("Menu");
    }

    public void NextButton1()
    {
        SceneManager.LoadScene("Challenge1"); // pick up + gates
    }

    public void NextButton2()
    {
        SceneManager.LoadScene("Challenge2"); // sniper + turret
    }

    public void NextButton3()
    {
        SceneManager.LoadScene("Challenge3"); // health pickup + ammo pickup
    }

    public void MainPlay()
    {
        SceneManager.LoadScene("Main"); // health pickup + ammo pickup
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
