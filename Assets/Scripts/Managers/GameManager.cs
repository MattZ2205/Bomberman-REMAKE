using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
                break;
            case gameStatus.gamePaused:
                Cursor.visible = true;
                Time.timeScale = 0;
                break;
            case gameStatus.gameEnd:
                Time.timeScale = 0;
                break;
        }
    }

    public void EndGame()
    {
        status = gameStatus.gameEnd;
    }
}
