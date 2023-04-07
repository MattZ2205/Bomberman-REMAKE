using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float explosionTimer;
    [SerializeField] GameObject[] explosion;
    [SerializeField] LayerMask mask;

    int explosionRange = 1;
    float timer;
    bool isDropped = false;

    Coroutine expl;

    private void OnEnable()
    {
        isDropped = true;
    }

    void Update()
    {
        if (isDropped) timer += Time.deltaTime;

        if (timer >= explosionTimer)
        {
            expl = StartCoroutine(Explosion());
        }
    }

    IEnumerator Explosion()
    {
        //explosion.SetActive(true);
        ControlNeighboor();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    void ControlNeighboor()
    {
        if (!Physics.Raycast(transform.position, transform.right, explosionRange, mask)) explosion[0].SetActive(true);
        if (!Physics.Raycast(transform.position, -transform.right, explosionRange, mask)) explosion[1].SetActive(true);
        if (!Physics.Raycast(transform.position, transform.up, explosionRange, mask)) explosion[2].SetActive(true);
        if (!Physics.Raycast(transform.position, -transform.up, explosionRange, mask)) explosion[3].SetActive(true);
        explosion[4].SetActive(true);
    }
}
