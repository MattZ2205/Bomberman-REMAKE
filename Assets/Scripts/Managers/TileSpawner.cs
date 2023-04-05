using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] Transform firstPoint, lastPoint;
    [SerializeField] int xSize, ySize;
    [SerializeField] GameObject tile;

    Vector3[,] tilePos;

    private void Start()
    {
        tilePos = new Vector3[xSize, ySize];
        for (int i = 0; i < xSize; i++)
            for (int j = 0; j < ySize; j++)
            {
                if (xSize % 2 == 1)
                {
                    if (j % 2 == 0) Instantiate(tile, tilePos[i, j], Quaternion.identity);
                }
                else
                {
                    Instantiate(tile, tilePos[i, j], Quaternion.identity);
                }
            }
    }
}
