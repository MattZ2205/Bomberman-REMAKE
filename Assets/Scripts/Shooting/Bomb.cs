using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float explosionTimer;
    [SerializeField] GameObject explosion;

    float timer;
    bool isDropped = false;

    private void OnEnable()
    {
        isDropped = true;
    }

    void Update()
    {
        if (isDropped) timer += Time.deltaTime;

        if (timer >= explosionTimer) Explosion();
    }

    void Explosion()
    {
        explosion.SetActive(true);
    }
}
