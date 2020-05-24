using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] public GameObject shard;
    [SerializeField] private AudioSource audioSrc;
    public GameObject obj;
    private Global script;

    // Start is called before the first frame update
    void Start()
    {
        script = obj.GetComponent<Global>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = script.musicVol;
    }

    void OnTriggerEnter(Collider other)
    {
        //for (int x = -2; x < 2; ++x)
        //    for (int y = -2; y < 2; ++y)
        //        for (int z = -2; z < 2; ++z)
        //        {
        //            //  Таким образом мы можем создать экземпляр объекта (шаблона объекта)
        //            var ball = Instantiate(shard) as GameObject;
        //            //   Указываем для вновь созданного объекта положение в пространстве
        //            ball.transform.position = transform.position + new Vector3(x * 0.4f, y * 0.4f, z * 0.4f);

        //            ball.GetComponent<Rigidbody>().velocity = 15.0f * Vector3.up;
        //            //ball.GetComponent<Rigidbody>().angularVelocity = 50.0f * transform.right;
        //        }
        //Destroy(gameObject);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet") return;

        audioSrc.PlayOneShot(audioSrc.clip);

        for (int x = -2; x < 2; ++x)
            for (int y = -2; y < 2; ++y)
                for (int z = -2; z < 2; ++z)
                {
                    //  Таким образом мы можем создать экземпляр объекта (шаблона объекта)
                    var ball = Instantiate(shard) as GameObject;
                    //   Указываем для вновь созданного объекта положение в пространстве
                    ball.transform.position = transform.position + new Vector3(x * 0.4f, y * 0.4f, z * 0.4f);

                    ball.GetComponent<Rigidbody>().velocity = 15.0f * Vector3.up;
                    //ball.GetComponent<Rigidbody>().angularVelocity = 50.0f * transform.right;
                }
        Destroy(gameObject);
    }
}
