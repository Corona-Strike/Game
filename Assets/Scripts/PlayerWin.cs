using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SpawnBehave;
public class PlayerWin : MonoBehaviour
{
    public UIController directorControl;
    void Update()
    {
        if (maxSceneObjects == MaxSceneObjects && ObjectsCount == 0 && Infected.Count == 0)
        {
            Destroy(GetComponent<CharacterController>());
            GetComponent<spin_body>().enabled = false;
            GetComponentInChildren<spin>().enabled = false;
            directorControl.deathText.text = "Вы выиграли!";
            directorControl.PlayerWinScreen();
        }
    }
}
