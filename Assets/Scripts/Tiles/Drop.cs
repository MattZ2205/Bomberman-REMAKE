using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : PowerUpManager
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DroppingPowerUp();
            PowerUpp();
            score.AggScore(20);
            gameObject.SetActive(false);
        }
    }

    void DroppingPowerUp()
    {
        if(actualPowerUp == typePowerUp.None)
        {
            actualPowerUp = (typePowerUp)Random.Range(1, (int)typePowerUp.COUNT);
        }
    }
}
