using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject startMenu, loadingScreen, continueText;
    [SerializeField] Button continueButton;
    [SerializeField] Stats stats;
    [SerializeField] Score score;


    private void Update()
    {
        if (score.score == 0)
        {
            continueButton.interactable = false;
        }
    }

    public void Continue()
    {
        startMenu.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        asyncOperation.allowSceneActivation = false;

        while (asyncOperation.progress <= 0.8f)
        {
            yield return null;
        }
        continueText.SetActive(true);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        asyncOperation.allowSceneActivation = true;
    }

    public void StartGame()
    {
        stats.ResetStats();
        score.ResetScore();
        Continue();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
