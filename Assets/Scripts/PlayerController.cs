using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float axesX, axesY;
    [SerializeField] float speed;
    bool isColl;

    void Start()
    {

    }

    void Update()
    {
        axesX = Input.GetAxis("Horizontal");    
        axesY = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(axesX, axesY) * speed * Time.deltaTime);
    }
}
