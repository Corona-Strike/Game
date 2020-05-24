using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCrush : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var walls = GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < walls.Length; ++i)
            walls[i].isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {

        var coll = GetComponent<Collider>();
        coll.enabled = false;

        if (collision.gameObject.tag != "Bullet") return;
        Debug.Log("Entered!");

        var walls = GetComponentsInChildren<Rigidbody>();
        foreach(var wall in walls)
        {
            wall.isKinematic = false;
            Debug.Log("Changed!");
        }

    }
}
