using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float explosionTimer;
    [SerializeField] GameObject explosion;
    [SerializeField] LayerMask mask;

    [HideInInspector] public int explosionRange;
    float timer;
    bool isDropped = false;

    private void OnEnable()
    {
        isDropped = true;
    }

    void Update()
    {
        if (isDropped) timer += Time.deltaTime;

        if (timer >= explosionTimer)
        {
            StartCoroutine(Explosion());
            timer = 0;
            isDropped = false;
        }
    }

    IEnumerator Explosion()
    {
        ControlNeighboor();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    void ControlNeighboor()
    {
        RaycastHit hit;
        for (int i = 1; i <= explosionRange; i++)
        {
            if (Physics.Raycast(transform.position, transform.right, out hit, i, mask))
            {
                if (hit.transform.gameObject.layer == 11)
                {
                    Instantiate(explosion, new Vector3(transform.position.x + i, transform.position.y, 0), Quaternion.identity, transform);
                    break;
                }
            }
            else
            {
                Instantiate(explosion, new Vector3(transform.position.x + i, transform.position.y, 0), Quaternion.identity, transform);
            }
        }

        for (int i = 1; i <= explosionRange; i++)
        {
            if (Physics.Raycast(transform.position, -transform.right, out hit, i, mask))
            {
                if (hit.transform.gameObject.layer == 11)
                {
                    Instantiate(explosion, new Vector3(transform.position.x - i, transform.position.y, 0), Quaternion.identity, transform);
                    break;
                }
            }
            else
            {
                Instantiate(explosion, new Vector3(transform.position.x - i, transform.position.y, 0), Quaternion.identity, transform);
            }
        }

        for (int i = 1; i <= explosionRange; i++)
        {
            if (Physics.Raycast(transform.position, transform.up, out hit, i, mask))
            {
                if (hit.transform.gameObject.layer == 11)
                {
                    Instantiate(explosion, new Vector3(transform.position.x, transform.position.y + i, 0), Quaternion.identity, transform);
                    break;
                }
            }
            else
            {
                Instantiate(explosion, new Vector3(transform.position.x, transform.position.y + i, 0), Quaternion.identity, transform);
            }
        }

        for (int i = 1; i <= explosionRange; i++)
        {
            if (Physics.Raycast(transform.position, -transform.up, out hit, i, mask))
            {
                if (hit.transform.gameObject.layer == 11)
                {
                    Instantiate(explosion, new Vector3(transform.position.x, transform.position.y - i, 0), Quaternion.identity, transform);
                    break;
                }
            }
            else
            {
                Instantiate(explosion, new Vector3(transform.position.x, transform.position.y - i, 0), Quaternion.identity, transform);
            }
        }

        Instantiate(explosion, transform.position, Quaternion.identity, transform);
    }
}
