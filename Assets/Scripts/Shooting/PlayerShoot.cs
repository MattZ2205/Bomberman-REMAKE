using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : Shooting
{
    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= rateo)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }
    }
}
