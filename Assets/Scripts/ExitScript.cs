using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour
{
    public Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
           exitButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void TaskOnClick()
    {
        Application.Quit(); 
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
