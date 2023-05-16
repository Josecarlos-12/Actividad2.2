using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlayer : MonoBehaviour, DamagePlayer
{
    [SerializeField, Header("Life")] private int life;

    [SerializeField, Header("Damage")] private int damage = 1;

    public int GetDamagePlayer()
    {
        return damage;
    }

    void ChangeLife(int value)
    {
        life += value;

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DamageEnemy>() != null)
        {
            ChangeLife(-other.gameObject.GetComponent<DamageEnemy>().GetDamage());
            Destroy(other.gameObject);
            print(life);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<DamageEnemy>() != null)
        {
            ChangeLife(-collision.gameObject.GetComponent<DamageEnemy>().GetDamage());
            print(life);
        }
    }
}
