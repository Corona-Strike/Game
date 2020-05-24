using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    [SerializeField] private GameObject breaker;
    [SerializeField] private GameObject crushableObj;
    [SerializeField] GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            //  Таким образом мы можем создать экземпляр объекта (шаблона объекта)
            //var ball = Instantiate(breaker) as GameObject;
            //   Указываем для вновь созданного объекта положение в пространстве
            //ball.transform.position = crushableObj.transform.position + Vector3.up * 4.0f;
            door.GetComponent<DoorScript>().Open();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            //  Таким образом мы можем создать экземпляр объекта (шаблона объекта)
            //var ball = Instantiate(breaker) as GameObject;
            //   Указываем для вновь созданного объекта положение в пространстве
            //ball.transform.position = crushableObj.transform.position + Vector3.up * 4.0f;
            door.GetComponent<DoorScript>().Close();
        }
    }
}
