using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    //  Список врагов (живых)
    public List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private GameObject place1;
    [SerializeField] private GameObject place2;
    [SerializeField] private GameObject place3;
    [SerializeField] private GameObject enemyPrefab;
    //public GameObject obj;
    //private Global script;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        //script = obj.GetComponent<Global>();
    }

    // Update is called once per frame
    void Update()
    {
        isPaused = Volume.pause;
        if (!isPaused)
        {
            //  Пункт 1. Если враг убит, то убрать его из списка.

            //  Пункт 2. Если количество врагов меньше заданного, то ?
            if (enemies.Count < 10 && Random.value < 0.01f)
            {
                GameObject placeToBirth = null;

                switch (Random.Range(1, 4))
                {
                    case 1: placeToBirth = place1; break;
                    case 2: placeToBirth = place2; break;
                    case 3: placeToBirth = place3; break;
                    default:
                        break;
                }

                var bodiesCount = placeToBirth.GetComponent<SpawnControl>().bodies;
                if (bodiesCount == 0)
                {
                    enemies.Add(Instantiate(enemyPrefab));
                    enemies[enemies.Count - 1].transform.position = placeToBirth.transform.position;
                }
            }
            //   С некоторой вероятностью решаем, порождать врага или нет?  random() < 1/100

            //   Выбираем случайно место для спавна и проверяем, что оно пустое? - потом!!
        }

    }
}

