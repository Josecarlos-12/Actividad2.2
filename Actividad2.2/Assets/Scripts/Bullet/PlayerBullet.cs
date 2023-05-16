using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet, DamagePlayer
{
    [SerializeField, Header("Damage")] private int damage;

    private void Start()
    {
        Destroy(gameObject, timeLife);
    }

    public int GetDamagePlayer()
    {
        return damage;
    }
}
