using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicAI : MonoBehaviour 
{
    public float obstacleRange = 5.0f;
    [SerializeField] private GameObject antiseptic = null;
    private DateTime d1 = default;
    private float bulletTime = 1.5f;
    private NavAgentExample agent;

    // Update is called once per frame
    void Start()
    {
        agent = GetComponent<NavAgentExample>();
        GuardianAI.OnCageEnter += () =>
        {
            agent.canFollowPlayer = false;
            agent._navAgent.ResetPath();
        };
        GuardianAI.OnCageExit += () =>
        {
            agent.canFollowPlayer = true;
        };
    }
    void Update()                                                 // Логика поведения Медика, она еще неполная
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        GameObject bullet = null;
        if (Physics.SphereCast(ray, 0.75f, out hit))
            if (hit.distance < obstacleRange)
            {
                if (hit.collider.gameObject.tag.Equals("Player")) // если колайдер = Player, то стреляет антисепиками в игрока
                {
                    if (d1 != default && (DateTime.Now - d1).TotalSeconds < bulletTime) return;

                    bullet = Instantiate(antiseptic);
                    bullet.transform.position = transform.position + transform.forward;
                    bullet.GetComponent<Rigidbody>().velocity = 35.0f * transform.forward;
                    d1 = DateTime.Now;
                }
            }
    }
}
