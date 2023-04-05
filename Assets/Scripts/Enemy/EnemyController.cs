using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float axesX, axesY, timer;
    CharacterController cc;

    [SerializeField] float speed;
    [SerializeField] float TimerMove;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        Debug.DrawRay(transform.position, transform.forward, Color.red, 0.1f);
        if (timer >= TimerMove)
        {
            timer = 0;
            do
            {
                axesX = Random.Range(-1, 2);
                axesY = Random.Range(-1, 2);
            } while (Physics.Raycast(transform.position, transform.forward, 1));
        }

        Move();
    }

    private void Move()
    {
        cc.Move(new Vector2(axesX, axesY) * speed * Time.deltaTime);
    }
}
