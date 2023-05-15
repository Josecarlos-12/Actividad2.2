using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletFollow : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;

    [SerializeField, Header("Damage")] private int damage;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, 3);
    }

    void Update()
    {
        Shot();
    }

    public void Shot()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public int GetDamage()
    {
        return damage;
    }
}
