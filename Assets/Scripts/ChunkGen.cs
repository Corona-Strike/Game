using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGen : MonoBehaviour {
	public Transform Points;
	public GameObject Prefabs;
	// Пока генерирую одну локацию, потом можно сделать несколько и создавать рандомно 
	void Start () {
        Instantiate(Prefabs, Points.position, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.tag.Equals("Player")) {
			Instantiate (Prefabs, Points.position, Quaternion.identity); 
			//Попытка сделать бесконечную генерацию
		}
	}
}
																							//бесполезный скрипт, так как никаких триггеров на чанк не навешен