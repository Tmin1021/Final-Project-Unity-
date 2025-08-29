using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float rotationSpeed = 100f;

    void Update()
    {
        this.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            OnPickup(activeWeapon);
            Destroy(gameObject);
        }
    }

    protected abstract void OnPickup(ActiveWeapon activeWeapon);
}
