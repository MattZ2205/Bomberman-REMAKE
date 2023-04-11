using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] LayerMask mask;

    [HideInInspector] public int life;

    void ManageLife()
    {
        if (life == 0)
        {
            StartCoroutine(GameManager.Instance.EndGame());
        }
        else
        {
            life--;
        }
    }

    private void Update()
    {
        Collider[] other = Physics.OverlapSphere(transform.position, radius, mask);
        if (other.Length > 0)
        {
            ManageLife();
        }
    }
}