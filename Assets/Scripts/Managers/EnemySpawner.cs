using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float enemyNumbers, timerSpawn;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemyExemple;

    List<GameObject> enemyList = new List<GameObject>();
    List<GameObject> deadEnemy = new List<GameObject>();
    float spawnedEnemy, timer;

    private void OnEnable()
    {
        Enemy.OnEnemyDeath += ManageDeadEnemy;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDeath -= ManageDeadEnemy;
    }

    private void Update()
    {
        if (spawnedEnemy == enemyNumbers)
        {
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }

        if (timer >= timerSpawn)
        {
            if (deadEnemy.Count > 0)
            {
                Respawn();
                spawnedEnemy++;
                timer = 0;
            }
            else if (deadEnemy.Count == 0)
            {
                SpawnEnemy();
                spawnedEnemy++;
                timer = 0;
            }
        }
    }

    void Respawn()
    {
        int indSpawn = Random.Range(0, spawnPoints.Length);
        deadEnemy[0].transform.position = spawnPoints[indSpawn].position;
        deadEnemy[0].SetActive(true);
        enemyList.Add(deadEnemy[0]);
        deadEnemy.RemoveAt(0);
    }

    void SpawnEnemy()
    {
        int indSpawn = Random.Range(0, spawnPoints.Length);
        enemyList.Add(Instantiate(enemyExemple, spawnPoints[indSpawn].position, Quaternion.identity));
    }

    private void ManageDeadEnemy()
    {
        for(int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i].GetComponent<Enemy>().isDead)
            {
                spawnedEnemy--;
                deadEnemy.Add(enemyList[i]);
                enemyList.RemoveAt(i);
            }
        }
    }
}