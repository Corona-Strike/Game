using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    public GameObject pause;
    private bool move = true;
    private bool statsRemove = true;
    public float musicVol;
    [SerializeField] Image crosshair;
    [SerializeField] GameObject stats;
    void Start()
    {
        Volume.pause = false;
        Cursor.visible = false;
        Application.targetFrameRate = 200;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        pause.SetActive(!pause.activeSelf);
        Volume.pause = !Volume.pause;
        move = !move;
        statsRemove = !statsRemove;
        stats.SetActive(statsRemove);
        if (!move) Time.timeScale = 0; else Time.timeScale = 1;
        crosshair.enabled = !crosshair.enabled;
        Cursor.visible = Volume.pause;
    }
}
