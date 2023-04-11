using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Score", fileName = "Score")]
public class Score : ScriptableObject
{
    public int score { get; private set; }

    public void ResetScore()
    {
        score = 0;
    }

    public void AggScore(int value)
    {
        score += value;
    }
}
