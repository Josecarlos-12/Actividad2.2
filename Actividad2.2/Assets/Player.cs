using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int life;

    void ChangeLife(int value)
    {
        life += value;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IDamage>() !=null)
        {
            ChangeLife(-collision.gameObject.GetComponent<IDamage>().GetDamage());
        }
    }
}
