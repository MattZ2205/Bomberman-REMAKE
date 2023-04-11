using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void DeadEnemyManagment();
    public static DeadEnemyManagment OnEnemyDeath;

    [SerializeField] Score score;

    [HideInInspector] public bool isDead = false;

    private void OnDisable()
    {
        OnEnemyDeath?.Invoke();
    }

    public void Kill()
    {
        isDead = true;
        score.AggScore(50);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            Kill();
        }
    }
}
