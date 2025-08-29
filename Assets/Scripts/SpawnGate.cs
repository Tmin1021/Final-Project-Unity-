using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject robotPrefab;
    [SerializeField] float spawnTime = 3f;
    [SerializeField] Transform spawnPoint;

    FirstPersonController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
        StartCoroutine(SpawnRobots());
    }

    IEnumerator SpawnRobots() 
    {
        while (player)
        {
            Instantiate(robotPrefab, spawnPoint.position, Quaternion.identity);
            // Instantiate(robotPrefab, spawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
