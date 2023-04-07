using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] Transform firstPoint, lastPoint;
    [SerializeField] int xSize, ySize;
    [SerializeField] GameObject tile;
    [SerializeField] GameObject[] drops;

    float probSpawn = 0.15f;
    GameObject[,] tiles;
    //Vector3[,] tilePos;
    //Vector3[,] emptyPos;

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
        //tilePos = new Vector3[xSize, ySize];
        //emptyPos = new Vector3[xSize, ySize];
        tiles = new GameObject[xSize, ySize];
        //InitializeArray();

        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                if (Random.value <= probSpawn)
                {
                    if (i % 2 == 1)
                    {
                        if (j % 2 == 0)
                        {
                            tiles[i, j] = Instantiate(tile, new Vector3(i, j, 0), Quaternion.identity);
                        }
                    }
                    else
                    {
                        tiles[i, j] = Instantiate(tile, new Vector3(i, j, 0), Quaternion.identity);
                    }
                    //    emptyPos[i, j] = new(-1, -1, -1);
                    //}
                    //else
                    //{
                    //    tilePos[i, j] = new(-1, -1, -1);
                    //}
                }
            }
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
                        int n = Random.Range(0, drops.Length);
                        Instantiate(drops[n], new Vector3(i, j, 0), Quaternion.identity);
                    }
                    //Array di oggetti che contiene le tiles
                    //Controllo di isDestroyed e relativo drop
                }
            }
        }
    }

    //void InitializeArray()
    //{
    //    Vector3 pos = Vector3.zero;
    //    for (int i = 0; i < xSize; i++)
    //    {
    //        pos.y = 0;
    //        for (int j = 0; j < ySize; j++)
    //        {
    //            tilePos[i, j] = pos;
    //            emptyPos[i, j] = pos;
    //            pos.y++;
    //        }
    //        pos.x++;
    //    }
    //}
}
