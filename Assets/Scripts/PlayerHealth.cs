using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int startHealth = 10;
    [SerializeField] Image[] shieldBars;

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
            Destroy(gameObject);
        }
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
