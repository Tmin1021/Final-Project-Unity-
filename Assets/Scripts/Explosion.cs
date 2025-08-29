using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float radius = 1.5f;
    void Start()
    {
        Explode();
    }

    // Update is called once per frame
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Explode()
    {
        // Do something
    }
}
