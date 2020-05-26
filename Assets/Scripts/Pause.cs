using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    public GameObject obj;
    private Global script;
    void Start()
    {
        script = obj.GetComponent<Global>();
    }

    public void Settings()
    {
        SpawnBehave.Infected.Clear();
        SceneManager.LoadScene(2); 
        pause.SetActive(!pause.activeSelf);
        script.Pause();
        Cursor.visible = true;
    }

    public void Menu()
    {
        SpawnBehave.Infected.Clear();
        SceneManager.LoadScene(0);
        pause.SetActive(!pause.activeSelf);
        script.Pause();
        Cursor.visible = true;
    }

    public void Continue()
    {
        script.Pause();
    }


}
