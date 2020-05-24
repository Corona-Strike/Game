using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour // логика поведения игрока при попадании в него антисептика или чего то еще (пока хз чего еще)
{
    [SerializeField] GameObject director = null; // ссылка на UI составляющую
    [SerializeField] GameObject player = null; // ссылка на игрока
    UIController directorControll;
    private int hp;
    void Start()
    {
        hp = 100;
        directorControll = director.GetComponent<UIController>(); 
        directorControll.UpdateHP(hp); // обновление хп со значением hp
    }

    void Update()
    {
        if (hp <= 0) // если хп меньше или равно 0, то уничтожаем игрока и выводим сообщение о проигрыше
        {
            PlayerDeath.Destroy(player);
            directorControll.PlayerDeathScreen();
            Cursor.visible = true;
        }

        if (transform.position.y < -3)
        {
            hp = 0;
        }
    }


    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag.Equals("EnemyBullet")) // если вражеская пуля попалп в игрока, то отнимаем 10 хп и обновляем статы hp
        {
            hp -= 10;
            directorControll.UpdateHP(hp);
        }
    }

}
