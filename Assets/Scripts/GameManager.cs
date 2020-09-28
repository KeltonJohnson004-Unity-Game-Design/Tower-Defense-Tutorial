using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public GameObject gameOverUI;
    public SceneFader sceneFader;
    public string sceneLoadName;
    public GameObject completeLevelUI;
    private void Start()
    {
        GameIsOver = false;
    }
    void Update()
    {
        if (GameIsOver)
            return;
        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }

        if(Input.GetKeyDown("e"))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true;

        completeLevelUI.SetActive(true);

    }
}
