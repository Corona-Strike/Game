using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    public GameObject player;
    public GameObject pause;
    public GameObject obj;
    private Global script;
    public bool isPaused;
    private bool move = true;
    public float musicVol;
    [SerializeField] Image crosshair;
    void Start()
    {
        crosshair.enabled = true;
        Cursor.visible = false;
        script = obj.GetComponent<Global>();
        musicVol = Volume.volume;
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
        script.isPaused = !script.isPaused;
        move = !move;
        if (!move) Time.timeScale = 0; else Time.timeScale = 1;
        Volume.pause = script.isPaused;
        crosshair.enabled = !crosshair.enabled;
        Cursor.visible = script.isPaused;
    }
}
