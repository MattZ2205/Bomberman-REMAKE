using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu, deadCanvas;
    [SerializeField] Stats stats;
    [SerializeField] Score score;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public enum gameStatus
    {
        gameRunning,
        gamePaused,
        gameEnd
    }
    public gameStatus status;

    private void Update()
    {
        switch (status)
        {
            case gameStatus.gameRunning:
                Cursor.visible = false;
                Time.timeScale = 1;
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    pauseMenu.SetActive(true);
                    status = gameStatus.gamePaused;
                }
                break;
            case gameStatus.gamePaused:
                Cursor.visible = true;
                Time.timeScale = 0;
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    pauseMenu.SetActive(false);
                    status = gameStatus.gameRunning;
                }
                break;
            case gameStatus.gameEnd:
                Cursor.visible = true;
                Time.timeScale = 1;
                break;
        }
    }

    public IEnumerator EndGame()
    {
        status = gameStatus.gameEnd;
        deadCanvas.SetActive(true);
        stats.ResetStats();
        score.ResetScore();
        yield return new WaitForSeconds(2);
        Back();
    }

    public void Restart()
    {
        stats.ResetStats();
        score.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
