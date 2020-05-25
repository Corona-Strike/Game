using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavAgentExample : MonoBehaviour
{
    public AIWaypointNetwork WaypointNetwork = null;
    [NonSerialized] public NavMeshAgent _navAgent = null;
    public int CurrentIndex = 0;
    [NonSerialized] public bool followsPlayer = false;
    [NonSerialized] public bool canFollowPlayer = true;
    private bool npcfollow = false;
    GameObject transf = default;
    
    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        if (WaypointNetwork == null) return;
        SetNextDestination(false);
    }

    void SetNextDestination(bool increment)
    {
        if (!WaypointNetwork) return;
        //int incStep = increment ? 1 : 0;
        //int nextmove = incStep + CurrentIndex >= WaypointNetwork.Waypoints.Count ? 0 : incStep + CurrentIndex;

        //if (WaypointNetwork.Waypoints[nextmove] != null)
        //{
        //    CurrentIndex = nextmove;
        //    Transform nextDestination = WaypointNetwork.Waypoints[nextmove];
        //    return;
        //}
        CurrentIndex = UnityEngine.Random.Range(1, WaypointNetwork.Waypoints.Count);

        _navAgent.destination = WaypointNetwork.Waypoints[CurrentIndex].position;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Player")) return;
        followsPlayer = true;
    }
    void OnTriggerExit(Collider collider)
    {
        if (!collider.CompareTag("Player")) return;
        followsPlayer = false;
    }
    void Update()
    {
        if (followsPlayer && canFollowPlayer && !gameObject.CompareTag("CommonNPC") && !gameObject.CompareTag("Infected"))
        {
            _navAgent.destination = SpawnBehave.player.position;
            return;
        }
        if (!gameObject.CompareTag("Medic"))
        {
            if ((_navAgent.remainingDistance <= _navAgent.stoppingDistance && !_navAgent.pathPending) || _navAgent.pathStatus == NavMeshPathStatus.PathInvalid)
                SetNextDestination(true);
            else if (_navAgent.isPathStale)
                SetNextDestination(false);
        }
        else if (SpawnBehave.Infected.Count != 0)
        {
            int corners = 1000000;
            if (npcfollow)
            {
                _navAgent.destination = transf.transform.position;
                if (_navAgent.pathStatus == NavMeshPathStatus.PathComplete) npcfollow = false;
                return;
            }
            foreach (var item in SpawnBehave.Infected)
            {
                NavMeshPath temp = new NavMeshPath();
                _navAgent.CalculatePath(item.transform.position, temp);
                if (temp.corners.Length < corners)
                {
                    corners = temp.corners.Length;
                    transf = item;
                    npcfollow = true;
                }
            }
        }
        else
        {
            if ((_navAgent.remainingDistance <= _navAgent.stoppingDistance && !_navAgent.pathPending) || _navAgent.pathStatus == NavMeshPathStatus.PathInvalid)
                SetNextDestination(true);
            else if (_navAgent.isPathStale)
                SetNextDestination(false);
        }
    }

}
