using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Stats stats;
    [SerializeField] protected Score score;
    [SerializeField] UIManager UIM;

    Coroutine allert;

    public enum typePowerUp
    {
        None,
        Range,
        Speed,
        Rateo,
        ExtraLife,
        COUNT
    }

    public static typePowerUp actualPowerUp;

    private void Start()
    {
        player.GetComponent<PlayerShoot>().rangeOfExplosion = stats.range;
        player.GetComponent<PlayerShoot>().rateo = stats.rateo;
        player.GetComponent<Character>().speed = stats.speed;
        player.GetComponent<MyPlayer>().life = stats.life;
        gameObject.SetActive(false);
    }

    protected void PowerUpp()
    {
        switch (actualPowerUp)
        {
            case typePowerUp.Range:
                RangePowerUp();
                actualPowerUp = typePowerUp.None;
                break;
            case typePowerUp.Speed:
                SpeedPowerUp();
                actualPowerUp = typePowerUp.None;
                break;
            case typePowerUp.Rateo:
                RateoPowerUp();
                actualPowerUp = typePowerUp.None;
                break;
            case typePowerUp.ExtraLife:
                ExtraLifePowerUp();
                actualPowerUp = typePowerUp.None;
                break;
        }
    }

    void RangePowerUp()
    {
        stats.range += 1;
        player.GetComponent<PlayerShoot>().rangeOfExplosion = stats.range;
        UIM.StartCanvas("Range", 'o');
    }

    void SpeedPowerUp()
    {
        stats.speed += 0.5f;
        player.GetComponent<Character>().speed = stats.speed;
        UIM.StartCanvas("Velocita'", 'a');
    }

    void RateoPowerUp()
    {
        stats.rateo = Mathf.Max(1, stats.rateo - 0.3f);
        player.GetComponent<PlayerShoot>().rateo = stats.rateo;
        UIM.StartCanvas("Rateo", 'o');
    }

    void ExtraLifePowerUp()
    {
        stats.life += 1;
        player.GetComponent<MyPlayer>().life = stats.life;
        UIM.StartCanvas("Vite", 'e');
    }
}
