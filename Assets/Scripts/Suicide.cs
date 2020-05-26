using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicide : MonoBehaviour
{
    private float eoLife;
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        eoLife = Time.time + lifeTime;
    }

    public void UpdateTime()
    {
        eoLife = Time.time + lifeTime;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > eoLife)
        {
            Destroy(gameObject);
            if (SpawnBehave.Infected.Contains(gameObject))
            {
                SpawnBehave.Infected.Remove(gameObject);
                SpawnBehave.ObjectsCount--;
            }
        }
    }
}
