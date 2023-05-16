using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
public class Enemy1 : MonoBehaviour, DamageEnemy
{
    [Header("Move")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform[] points;
    [SerializeField] private int destPoint = 0;
    [SerializeField] private int distancePoint = 1;

    [Header("Shot")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float time, maxTime;
    [SerializeField] private Transform shotPosition;

    [SerializeField, Header("Life")] private int life;

    [SerializeField, Header("Damage")] private int damage = 1;

    private void Update()
    {

        if (agent.remainingDistance < distancePoint)
        {
            GoToNextPoint();
        }
        Shot();
    }

    public void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
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
