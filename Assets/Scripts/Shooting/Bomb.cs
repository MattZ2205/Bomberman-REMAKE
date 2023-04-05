using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float explosionTimer;

    float timer;

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= explosionTimer)
        {
            Explosion();
        }
    }

    void Explosion()
    {

    }
}
