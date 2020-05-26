using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueScript : MonoBehaviour
{
    public Button playButton;
    public Global global;
    void Start()
    {
        playButton.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        global.Pause();
    }
}
