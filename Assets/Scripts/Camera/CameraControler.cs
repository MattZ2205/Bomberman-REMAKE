using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float cameraSpeed;
    [SerializeField] Transform[] lockPoints;

    Vector3 shifting;

    private void Start()
    {
        shifting = transform.position;
    }

    private void Update()
    {
        if ((player.transform.position.x >= lockPoints[0].position.x || player.transform.position.x >= lockPoints[3].position.x) &&
            (player.transform.position.x <= lockPoints[1].position.x || player.transform.position.x <= lockPoints[2].position.x))
        {
            shifting.x = player.transform.position.x;
        }

        if ((player.transform.position.y <= lockPoints[0].position.y || player.transform.position.y <= lockPoints[1].position.y) &&
            (player.transform.position.y >= lockPoints[2].position.y || player.transform.position.y >= lockPoints[3].position.y))
        {
            shifting.y = player.transform.position.y;
        }

        transform.position = Vector3.Lerp(transform.position, shifting, cameraSpeed * Time.deltaTime);
    }
}
