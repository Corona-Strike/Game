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
        NPCInfection.OnInfection += e =>
        {
            eoLife = e + lifeTime;
        };
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > eoLife)
        {
            Destroy(gameObject);
            if (SpawnBehave.Infected.Contains(gameObject))
                SpawnBehave.Infected.Remove(gameObject);
        }
    }
}
