using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] public float rateo;
    [SerializeField] GameObject bomb;
    [HideInInspector] public int rangeOfExplosion;

    protected void Shoot()
    {
        GameObject b = bomb;
        b.GetComponent<Bomb>().explosionRange = rangeOfExplosion;
        Instantiate(b, new (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y)), Quaternion.identity);
    }
}