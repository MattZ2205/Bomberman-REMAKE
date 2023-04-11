using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Stats", fileName = "Stats")]
public class Stats : ScriptableObject
{
    public float rateo, speed;
    public int range, life;

    public void ResetStats()
    {
        rateo = 5;
        speed = 3;
        range = 1;
        life = 1;
    }
}
