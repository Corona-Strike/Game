using ErosionBrushPlugin;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

public class SpawnBehave : MonoBehaviour
{
    [System.NonSerialized] public static List<GameObject> Infected = new List<GameObject>();
    [SerializeField] private GameObject Medic, Guard, Common = null;
    [SerializeField] public Transform Player; 
    [SerializeField] public static Transform player;
    public static int ObjectsCount;
    public static int maxSceneObjects;
    public const int MaxObjectsCount = 12;
    public const int MaxSceneObjects = 30;
    void Start()
    {
        InvokeRepeating(nameof(InstantiateObjects), 0, 6);
    }
    void Update()
    {
        #region статическая ссылка на игрока
        player = Player;
        #endregion
    }
    void InstantiateObjects()
    {
        if (ObjectsCount >= MaxObjectsCount || maxSceneObjects >= MaxSceneObjects) return;
        switch (Random.Range(1,20))
        {
            case 1: case 2: case 3: case 4:
                maxSceneObjects++;
                ObjectsCount++;
                Instantiate(Guard, gameObject.transform.position, Quaternion.identity);
                break;
            case 5: case 6: case 7: case 8: case 9: case 10:
                maxSceneObjects++;
                ObjectsCount++;
                Instantiate(Medic, gameObject.transform.position, Quaternion.identity);
                break;
            case 11: case 12: case 13: case 14: case 15: case 16: case 17: case 18: case 19:
                maxSceneObjects++;
                ObjectsCount++;
                Instantiate(Common, gameObject.transform.position, Quaternion.identity);
                break;
        }
    }
}
