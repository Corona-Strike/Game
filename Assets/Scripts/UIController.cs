using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    [SerializeField] public Text scoreLabel;
    [SerializeField] public Text deathText;
    [SerializeField] public Text hpCount;
    [SerializeField] public Text statText;
    [SerializeField] public Image crosshair;

    bool countWasUpdated = false;

    // Update is called once per frame
    void Update()
    {
        statText.text = "Зараженных: " + SpawnBehave.Infected.Count;
        if (!countWasUpdated)
        {
            string tm = Time.realtimeSinceStartup.ToString().Substring(0,4);
            scoreLabel.text = "Время : " + tm;
        }
    }

    public void UpdatePolenos(int counter)
    {
        scoreLabel.text = "Вирусов : " + counter.ToString();
        countWasUpdated = true;
    }
    public void PlayerDeathScreen()
    {
        crosshair.enabled = false;
        statText.text = "Зараженных: " + SpawnBehave.Infected.Count;
        deathText.text = "Вы проиграли!";
        Invoke("RealodLevel", 3);
    }
    public void PlayerWinScreen()
    {
        crosshair.enabled = false;
        statText.text = "Зараженных: " + SpawnBehave.Infected.Count;
        deathText.text = "Вы выиграли!";
        Invoke("RealodLevel", 3);

    }
    public void RealodLevel()
    {
        SpawnBehave.Infected.Clear();
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }

    public void UpdateHP(int hp)
    {
        hpCount.text = $"HP : {hp}";
    }
}
