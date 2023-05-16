using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour, DamageEnemy
{
    [Header("Move"), SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject player;

    [Header("Shot"), SerializeField] private GameObject bullet;
    [SerializeField] private Transform shotPosition;
    [SerializeField] private float time, maxTime;

    [SerializeField, Header("Life")] private int life;

    [SerializeField, Header("Damage")] private int damage = 1;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        Move();
        Shot();
    }

    public void Move()
    {
        if(player!= null)
        {
            agent.destination = player.transform.position;
            transform.LookAt(player.transform.position);
        }        
    }

    public void Shot()
    {
        time += Time.deltaTime;

        if (time >= maxTime)
        {
            time = 0;
            Instantiate(bullet, shotPosition.transform.position, shotPosition.transform.rotation);
        }
    }
    void ChangeLife(int value)
    {
        life += value;

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetDamage()
    {
        return damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DamagePlayer>() != null)
        {
            ChangeLife(-other.gameObject.GetComponent<DamagePlayer>().GetDamagePlayer());
            Destroy(other.gameObject);
            print(life);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<DamagePlayer>() != null)
        {
            ChangeLife(-collision.gameObject.GetComponent<DamagePlayer>().GetDamagePlayer());
            print(life);
        }
    }

}
