using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        SpawnBehave.ObjectsCount = 0;
        SpawnBehave.maxSceneObjects = 0;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadScene(2);
    }
    public void Multiplayer()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
        SpawnBehave.ObjectsCount = 0;
        SpawnBehave.maxSceneObjects = 0;
    }
}
