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

    int botsLeft = 0;
    void Start()
    {
        // starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
    }

    public void BotsLeft(int amount)
    {
        botsLeft += amount;
        botsText.text = "Bots: " + botsLeft.ToString();
        if (botsLeft <= 0)
        {
            victoryText.SetActive(true);
        }
    }
    public void RestartButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        // starterAssetsInputs.SetCursorState(true);
        SceneManager.LoadScene(currentScene);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
