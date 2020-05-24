using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public GameObject obj;
    private Global script;
    public int bodies = 0;
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
        bodies += 1;
      
    }

    void OnTriggerExit(Collider other)
    {
        bodies -= 1;
    }
}
