using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void DeadEnemyManagment();
    public static DeadEnemyManagment OnEnemyDeath;

    [HideInInspector] public bool isDead = false;

    [HideInInspector] public bool IsDead { get; set; }

    private void OnDisable()
    {
        OnEnemyDeath?.Invoke();
    }

    public void Kill()
    {
        isDead = true;
        gameObject.SetActive(false);
    }
}
