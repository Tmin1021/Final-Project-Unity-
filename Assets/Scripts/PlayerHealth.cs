using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using StarterAssets;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int startHealth = 10;
    [SerializeField] Image[] shieldBars;
    [SerializeField] GameObject gameOverCanvas;

    int currentHealth;
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = startHealth;
        AdjustShieldUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        AdjustShieldUI();
        // Debug.Log(damage + "damage taken");
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverCanvas.SetActive(true);
        StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(false);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void AdjustShieldUI()
    {
        for (int i = startHealth-1; i >= currentHealth; i--)
        {
            shieldBars[i].gameObject.SetActive(false);
        }
    }
}
