using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet, DamageEnemy
{
    [SerializeField, Header("Damage")] private int damage;

    private void Start()
    {
        Destroy(gameObject, timeLife);
    }

    public int GetDamage()
    {
        return damage;
    }
}
