using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Rigidbody rb;

    [SerializeField]
    protected float speed;

    protected virtual void Update()
    {
        rb.velocity = Vector3.forward * speed;
    }
}
