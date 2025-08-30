using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactioLayers;

    public void Shoot(WeaponSO weaponSO)
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactioLayers, QueryTriggerInteraction.Ignore))
        {
            muzzleFlash.Play();
            EnemyHealth enemy = hit.collider.GetComponentInParent<EnemyHealth>();
            Instantiate(weaponSO.hitVFX, hit.point, Quaternion.identity);
            if (enemy)
            {
                enemy.TakeDamage(weaponSO.damage);
                // Debug.Log("Hit");
            }

            // enemy?.TakeDamage(weaponSO.damage);
        }
    }
}