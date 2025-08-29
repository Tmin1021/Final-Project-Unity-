using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class WeaponSO : ScriptableObject
{
    public GameObject weaponPrefab;
    public int damage;
    public float fireRate;
    public GameObject hitVFX;
    public bool isAutomatic = false;
    public bool canZoom = false;
    public float zoomFOV = 10f;
    public float rotationSpeed = 0.3f;
    public int magazineSize = 12;
}
