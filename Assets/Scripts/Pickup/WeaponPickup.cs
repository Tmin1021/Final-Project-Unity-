using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Pickup
{
    // Start is called before the first frame update
    [SerializeField] WeaponSO weaponSO;

    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        activeWeapon.SwitchWeapon(weaponSO);
    }
}
