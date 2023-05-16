using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 movementVector = Vector3.zero;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 velocity = Vector3.zero;

        if (horizontal != 0 || vertical != 0)
        {
            movementVector = (transform.forward * vertical + transform.right * horizontal).normalized;
            velocity = movementVector * speed;
        }     

        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }    
   
}
