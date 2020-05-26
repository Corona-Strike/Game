using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{




    
    /// <summary>
    /// Нам необходимо открытое поле типа GameObject, чтобы из редактора можно было указывать конкретный объект (префаб) для создания
    /// </summary>
    public GameObject sphere_;

    public GameObject bullet;


    public float R = 1.0f;
    public List<GameObject> list = new List<GameObject>();

    //  Объект, к скрипту которого хотим обратиться
    [SerializeField] GameObject director;
    [SerializeField] AudioSource soundSource;
    [SerializeField] float bulletSpeed;
    //  
    private UIController outerScript;


    //  Количество поленьев
    [SerializeField] private int ammoMaxCount = 10;
    private int ammoCount = 0;

    // При старте ничего особого не делаем
    void Start()
    {
        ammoCount = ammoMaxCount;
        outerScript = director.GetComponent<UIController>();
        outerScript.UpdatePolenos(ammoCount);

    }

    void Update()
    {
        soundSource.volume = Volume.volume;
        if (!Volume.pause)
        {
            soundSource.volume = Volume.volume;
            //  Если нажата кнопка мыши, то создаём объект
            if (Input.GetMouseButtonDown(0))
            {
                if (ammoCount <= 0)
                    return;
                ammoCount--;
                outerScript.UpdatePolenos(ammoCount);
                //soundSource.PlayOneShot(soundSource.clip);
                soundSource.Play();

                //  Таким образом мы можем создать экземпляр объекта (шаблона объекта)
                var ball = Instantiate(bullet) as GameObject;
                //   Указываем для вновь созданного объекта положение в пространстве
                ball.transform.position = transform.position + transform.forward;

                ball.GetComponent<Rigidbody>().velocity = bulletSpeed * transform.forward;
                ball.GetComponent<Rigidbody>().angularVelocity = bulletSpeed * transform.right;
                //  Так можно создавать примитивы объектов (но нам это не очень интересно)
                //var ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);




                //  Вновь созданный шар - объект, состоящий из различных компонентов. Если мы хотим 
                //    для какого-то из его компонентов изменить какие-то свойства, то нужно сначала найти этот 
                //    компонент методом GetComponent, после чего можно менять свойства этого компонента.

                //  Раскомментируйте эту строку, и проверьте, что изменится
                //  ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 1f, 0.5f);

            }
            else
            if (Input.GetKey(KeyCode.R))
            {
                ammoCount = ammoMaxCount;
                outerScript.UpdatePolenos(ammoCount);

            }
        

            for (int i = 0; i < list.Count; i++)
            {
                list[i].transform.RotateAround(Vector3.up, Vector3.up, 1.0f);
            }
        }
    }
}
