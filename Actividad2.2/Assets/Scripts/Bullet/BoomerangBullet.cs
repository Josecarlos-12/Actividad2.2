using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBullet : MonoBehaviour, DamageEnemy
{
    [SerializeField, Header("Boomerang")] private GameObject bullet;
    [SerializeField] private GameObject objectFollow, playerPosition,shotPosition, container;
    [SerializeField] private float speed;
    [SerializeField] private bool returnBullet, distance;

    [SerializeField, Header("Damage")] private int damage = 1;

    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player");
        objectFollow = playerPosition;
    }


    void Update()
    {
        Boomerag();
        DestroyObject();
    }
    
    public void DestroyObject()
    {
        if(container == null)
        {
            Destroy(gameObject);
        }
    }

    public void Boomerag()
    {
        if(container != null && playerPosition!=null)
        {
            transform.position = Vector3.MoveTowards(transform.position, objectFollow.transform.position, speed * Time.deltaTime);

            if (returnBullet && Vector3.Distance(transform.position, shotPosition.transform.position) < 2)
            {
                if (!distance)
                {
                    returnBullet = false;
                    StartCoroutine("Follow");
                    return;
                }
            }
        }        
    }

    public IEnumerator Follow()
    {
        yield return new WaitForSeconds(2);
        objectFollow = playerPosition;        
    }

    public int GetDamage()
    {
        return damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objectFollow = shotPosition;
            returnBullet = true;
        }
    }
}
