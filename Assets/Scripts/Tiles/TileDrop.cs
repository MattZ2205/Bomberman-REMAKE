using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDrop : MonoBehaviour
{
    public delegate void DestroyTile();
    public static DestroyTile OnTileDestroy;

    [SerializeField] float dropRate;
    public bool isDestroy = false;

    private void Update()
    {
        if (transform.position.z != 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            if (Random.value <= dropRate)
            {
                isDestroy = true;
                OnTileDestroy?.Invoke();
            }
            Destroy(gameObject);
        }
    }
}
