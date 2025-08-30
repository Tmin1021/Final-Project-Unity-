using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int startHealth = 3;
    [SerializeField] GameObject robotExplosionVFX;

    GameManager gameManager;
    int currentHealth;
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = startHealth;
    }

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.BotsLeft(1);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            GoExplode();
        }
    }

    public void GoExplode()
    {
        Instantiate(robotExplosionVFX, transform.position, Quaternion.identity);
        gameManager.BotsLeft(-1);
        Destroy(gameObject);
    }
}
