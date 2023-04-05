using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float axesX, axesY;
    CharacterController cc;

    [SerializeField] float speed;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        axesX = Input.GetAxisRaw("Horizontal");
        axesY = Input.GetAxisRaw("Vertical");

        Move();
    }

    private void Move()
    {
        cc.Move(new Vector2(axesX, axesY) * speed * Time.deltaTime);
    }
}
