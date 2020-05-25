﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class NPCInfection : MonoBehaviour
{
    int infections = 0;
    Renderer[] renderer = null;
    public static event Action<float> OnInfection;
    void Start()
    {
        GetComponent<Suicide>().enabled = false;
    }

    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            infections += 1;
            if (infections == 1)
            {
                Volume.infected += 1;
            }
            switch (gameObject.tag)
            {
                case "Medic":
                    gameObject.GetComponent<MedicAI>().enabled = false;
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    renderer = gameObject.GetComponentsInChildren<Renderer>();
                    gameObject.tag = "Infected";
                    GetComponent<InfectionLogic>().enabled = true;
                    SpawnBehave.Infected.Add(gameObject);
                    foreach (var item in renderer)
                    {
                        item.material.color = Color.red;
                    }
                    GetComponent<Suicide>().enabled = true;
                    OnInfection?.Invoke(Time.time);
                    SpawnBehave.ObjectsCount--;
                    break;
                case "Guardian":
                    gameObject.GetComponent<GuardianAI>().enabled = false;
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    renderer = gameObject.GetComponentsInChildren<Renderer>();
                    gameObject.tag = "Infected";
                    GetComponent<InfectionLogic>().enabled = true;
                    SpawnBehave.Infected.Add(gameObject);
                    foreach (var item in renderer)
                    {
                        item.material.color = Color.red;
                    }
                    GetComponent<Suicide>().enabled = true;
                    OnInfection?.Invoke(Time.time);
                    SpawnBehave.ObjectsCount--;
                    break;
                case "CommonNPC":
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    renderer = gameObject.GetComponentsInChildren<Renderer>();
                    gameObject.tag = "Infected";
                    GetComponent<InfectionLogic>().enabled = true;
                    SpawnBehave.Infected.Add(gameObject);
                    foreach (var item in renderer)
                    {
                        item.material.color = Color.red;
                    }
                    GetComponent<Suicide>().enabled = true;
                    OnInfection?.Invoke(Time.time);
                    SpawnBehave.ObjectsCount--;
                    break;
                default:
                    break;
            }
            
        }
    }
}
