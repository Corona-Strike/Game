using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    [SerializeField] private Text scoreLabel;
    [SerializeField] private Text deathText;
    [SerializeField] private Text hpCount;
    [SerializeField] private Text statText;
    [SerializeField] Image crosshair;

    bool countWasUpdated = false;

    // Update is called once per frame
    void Update()
    {
        if (!countWasUpdated)
        {
            string tm = Time.realtimeSinceStartup.ToString().Substring(0,4);
            scoreLabel.text = "Время : " + tm;
        }
    }

    public void UpdatePolenos(int counter)
    {
        statText.text = "Заражено: " + Volume.infected;
        scoreLabel.text = "Вирусов : " + counter.ToString();
        countWasUpdated = true;
    }
    public void PlayerDeathScreen()
    {
        crosshair.enabled = false;
        statText.text = "Зараженных: " + Volume.infected;
        deathText.text = "Вы проиграли!";
        Volume.infected = 0;
        Invoke("RealodLevel", 3);
    }

    public void RealodLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateHP(int hp)
    {
        hpCount.text = $"HP : {hp}";
    }
}
