using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy3 : MonoBehaviour, DamageEnemy
{
    [SerializeField, Header("Move")] private Transform player;
    [SerializeField] private float distanceToPlayer;
    [SerializeField] private float moveSpeed;
    [SerializeField] private NavMeshAgent navMeshAgent;

    [SerializeField, Header("Life")] private int life;

    [SerializeField, Header("Damage")] private int damage = 1;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Back();
    }

    public void Back()
    {
        if(player!= null)
        {
            transform.LookAt(player.position);

            if (Vector3.Distance(transform.position, player.position) < distanceToPlayer)
            {

                Vector3 direction = transform.position - player.position;
                direction.Normalize();


                Vector3 targetPosition = transform.position + direction * distanceToPlayer;
                navMeshAgent.SetDestination(targetPosition);


                navMeshAgent.speed = moveSpeed;
            }
            else
            {

                navMeshAgent.speed = 0f;
            }
        }
        
    }

    public int GetDamage()
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceToPlayer);
    }

}
