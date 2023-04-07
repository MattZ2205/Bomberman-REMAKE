using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] Transform firstPoint, lastPoint;
    [SerializeField] int xSize, ySize;
    [SerializeField] GameObject tile;

    float probSpawn = 0.15f;
    Vector3[,] tilePos;

    private void Start()
    {
        tilePos = new Vector3[xSize, ySize];

        Vector3 pos = Vector3.zero;
        for (int i = 0; i < xSize; i++)
        {
            pos.y = 0;
            for (int j = 0; j < ySize; j++)
            {
                tilePos[i, j] = pos;
                pos.y++;
            }
            pos.x++;
        }

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
                            Instantiate(tile, tilePos[i, j], Quaternion.identity);
                        }
                    }
                    else
                    {
                        Instantiate(tile, tilePos[i, j], Quaternion.identity);
                    }
                }
            }
        }
    }
}
