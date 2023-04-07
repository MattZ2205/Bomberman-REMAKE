using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] protected float rateo;
    [SerializeField] GameObject bomb;

    protected void Shoot()
    {
        Instantiate(bomb, new (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y)), Quaternion.identity);
    }
}