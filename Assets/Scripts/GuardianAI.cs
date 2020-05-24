using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class GuardianAI : MonoBehaviour
{
    public static event Action OnCageEnter;
    public static event Action OnCageExit;
    public GameObject Cage;
    public Transform CageSpawn;
    public float obstacleRange = 5.0f;
    private static bool canInst = true;
    private NavAgentExample agent = null;
    private DateTime t1;

    private float waittime = 3f;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        GameObject cage = null;
        agent = GetComponent<NavAgentExample>(); 
        if (Physics.SphereCast(ray, 0.9f, out hit))
            if (hit.distance < obstacleRange)
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                { 
                    if (!canInst) return;
                    cage = Instantiate(Cage, hit.transform.position, Quaternion.identity);
                    cage.GetComponent<Rigidbody>().velocity = -0.0f * transform.up;
                    Destroy(cage, waittime); 
                    t1 = DateTime.Now;
                    agent.canFollowPlayer = false;
                    agent._navAgent.ResetPath();
                    canInst = false;
                    OnCageEnter?.Invoke();
                    #region Зачем это?

                    //if (hit.collider.gameObject.CompareTag("CommonNPC"))
                    //{
                    //    var cage = Instantiate(Cage, hit.transform.position, Quaternion.identity);
                    //    cage.GetComponent<Rigidbody>().velocity = -0.0f * transform.up;
                    //    Destroy(cage, waittime);
                    //}

                    #endregion
                }
            }

        if (t1 != default && (long)(DateTime.Now - t1).TotalSeconds > waittime)
        {
            agent.canFollowPlayer = true;
            canInst = true;
            OnCageExit?.Invoke();
        }
    }
}
