using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public float musicVol = 1f;
    public int quality = 0;
    public bool isFullScreen = true;
    [SerializeField] Slider volume;
    [SerializeField] Dropdown graphic;
    [SerializeField] Toggle fullscreen;
    // Start is called before the first frame update
    void Start()
    {
        volume.value = Volume.volume;
        graphic.value = QualitySettings.GetQualityLevel();
        fullscreen.isOn = isFullScreen;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Cancel()
    {
        SceneManager.LoadScene(0);
    }

    public void setVolume(float vol)
    {
        musicVol = vol;
    }

    public void setQuality(int q)
    {
        quality = q;
    }

    public void setFullScreen(bool screen)
    {
        isFullScreen = screen;
    }

    public void Apply()
    {
        Screen.fullScreen = isFullScreen;
        QualitySettings.SetQualityLevel(quality);
        SceneManager.LoadScene(0);
        Volume.volume = musicVol;
    }


    }
