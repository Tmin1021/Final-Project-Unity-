using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform turretHead;
    [SerializeField] Transform player;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] float fireRate = 2f;
    [SerializeField] int damage = 2;
    FirstPersonController playerFPC;
    void Start()
    {
        playerFPC = FindFirstObjectByType<FirstPersonController>();
        StartCoroutine(FireRoutine());
    }
    void Update()
    {
        turretHead.LookAt(player);
    }

    IEnumerator FireRoutine()
    {
        while (playerFPC)
        {
            yield return new WaitForSeconds(fireRate);
            Projectile projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, turretHead.rotation).GetComponent<Projectile>();
            projectile.Init(damage);
        }
    }
}
