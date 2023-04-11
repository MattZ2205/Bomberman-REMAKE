using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class UIManager : MonoBehaviour
{
    [SerializeField] Score scoreManager;
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text PowerUpAllert;

    Coroutine allert;

    private void Update()
    {
        score.text = scoreManager.score.ToString();
    }

    public void StartCanvas(string s, char c)
    {
        if (allert != null) StopCoroutine(allert);
        allert = StartCoroutine(TakePowerUp(s, c));
    }

    public IEnumerator TakePowerUp(string PU, char f)
    {
        PowerUpAllert.gameObject.SetActive(true);
        PowerUpAllert.text = PU + " aumentat" + f;
        yield return new WaitForSeconds(1.5f);
        PowerUpAllert.gameObject.SetActive(false);
    }
}