using UnityEngine;

public class SpawnBehave : MonoBehaviour
{
    [SerializeField] private GameObject Medic, Guard, Common = null;
    [SerializeField] public Transform Player; 
    [SerializeField] public static Transform player;
    public static int ObjectsCount;
    public static int maxSceneObjects;
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
        if (ObjectsCount >= 20 || maxSceneObjects >= 50) return;
        switch (Random.Range(1,20))
        {
            case 1: case 2: case 3: case 4:
                Instantiate(Guard, gameObject.transform.position, Quaternion.identity);
                maxSceneObjects++;
                ObjectsCount++;
                break;
            case 5: case 6: case 7: case 8: case 9: case 10:
                Instantiate(Medic, gameObject.transform.position, Quaternion.identity);
                maxSceneObjects++;
                ObjectsCount++;
                break;
            case 11: case 12: case 13: case 14: case 15: case 16: case 17: case 18: case 19:
                Instantiate(Common, gameObject.transform.position, Quaternion.identity);
                maxSceneObjects++;
                ObjectsCount++;
                break;
        }
    }
}
