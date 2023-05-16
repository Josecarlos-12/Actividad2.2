using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected float speed;
    [SerializeField] protected float timeLife;

    protected virtual void Update()
    {
        rb.velocity = transform.forward * speed;
    }
}
