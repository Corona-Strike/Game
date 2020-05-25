using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionLogic : MonoBehaviour
{
    private void Start()
    {
        enabled = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!enabled) return;
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            GetComponent<Suicide>().enabled = false;

            if (gameObject.name == "SampleCommonNPC(Clone)" || gameObject.name == "CommonNPC(Clone)")
            {
                tag = "CommonNPC";
                SpawnBehave.Infected.Remove(gameObject);
                GetComponent<Renderer>().material.color = Color.white;
                var renderer = gameObject.GetComponentsInChildren<Renderer>();
                foreach(var item in renderer)
                {
                    item.material.color = Color.white;
                }
            }
            if (gameObject.name == "SampleMedicNPC(Clone)" || gameObject.name == "MedicNPC(Clone)")
            {
                tag = "Medic";
                SpawnBehave.Infected.Remove(gameObject);
                GetComponent<Renderer>().material.color = Color.green;
                var renderer = gameObject.GetComponentsInChildren<Renderer>();
                foreach (var item in renderer)
                {
                    item.material.color = Color.green;
                }
            }
            if (gameObject.name == "SampleGuardianNPC(Clone)" || gameObject.name == "GuardianNPC(Clone)")
            {
                tag = "Guardian";
                SpawnBehave.Infected.Remove(gameObject);
                GetComponent<Renderer>().material.color = Color.blue;
                var renderer = gameObject.GetComponentsInChildren<Renderer>();
                foreach (var item in renderer)
                {
                    item.material.color = Color.blue;
                }
            }
        }
    }
    private void Update()
    {
        
    }
}
