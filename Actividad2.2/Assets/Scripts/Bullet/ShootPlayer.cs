using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject point;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, point.transform.position, point.transform.rotation);
        }  
    }
}
