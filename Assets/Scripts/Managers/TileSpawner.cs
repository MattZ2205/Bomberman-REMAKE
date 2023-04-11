using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] int xSize, ySize;
    [SerializeField] GameObject tile;
    [SerializeField] GameObject drop;
    [SerializeField] Transform[] spawnPoints;

    float probSpawn = 0.15f;
    GameObject[,] tiles;
    int nTiles = 0, capTiles = 5;

    private void OnEnable()
    {
        TileDrop.OnTileDestroy += Drop;
    }

    private void OnDisable()
    {
        TileDrop.OnTileDestroy -= Drop;
    }

    private void Start()
    {
        tiles = new GameObject[xSize, ySize];
        SpawnTiles();
    }

    private void Update()
    {
        if (nTiles < capTiles)
        {
            SpawnTiles();
        }
    }

    public void Drop()
    {
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                if (tiles[i, j] != null)
                {
                    if (tiles[i, j].GetComponent<TileDrop>().isDestroy)
                    {
                        if (!drop.activeSelf)
                        {
                            drop.transform.position = new Vector3(i, j, 0);
                            drop.SetActive(true);
                        }
                        nTiles--;
                    }
                }
            }
        }
    }

    void SpawnTiles()
    {
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                bool isSpawnable = true;
                for (int x = 0; x < spawnPoints.Length; x++)
                {
                    if ((spawnPoints[x].position.x == i && spawnPoints[x].position.y == j) ||
                        (spawnPoints[x].position.x + 1 == i && spawnPoints[x].position.y == j) ||
                        (spawnPoints[x].position.x - 1 == i && spawnPoints[x].position.y == j) ||
                        (spawnPoints[x].position.x == i && spawnPoints[x].position.y + 1 == j) ||
                        (spawnPoints[x].position.x == i && spawnPoints[x].position.y - 1 == j))
                    {
                        isSpawnable = false;
                    }
                }

                if (Random.value <= probSpawn && isSpawnable)
                {
                    if (tiles[i, j] == null)
                    {
                        if (i % 2 == 1)
                        {
                            if (j % 2 == 0)
                            {
                                tiles[i, j] = Instantiate(tile, new Vector3(i, j, 0), Quaternion.identity);
                                nTiles++;
                            }
                        }
                        else
                        {
                            tiles[i, j] = Instantiate(tile, new Vector3(i, j, 0), Quaternion.identity);
                            nTiles++;
                        }
                    }
                }
            }
        }
    }
}
