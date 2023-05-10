using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector3.forward * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
