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
    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        if (WaypointNetwork == null) return;
        SetNextDestination(false);
    }

    void SetNextDestination(bool increment)
    {
        if (!WaypointNetwork) return;
        int incStep = increment ? 1 : 0;
        int nextmove = incStep + CurrentIndex >= WaypointNetwork.Waypoints.Count ? 0 : incStep + CurrentIndex;

        if (WaypointNetwork.Waypoints[nextmove] != null)
        {
            CurrentIndex = nextmove;
            Transform nextDestination = WaypointNetwork.Waypoints[nextmove];
            _navAgent.destination = nextDestination.position;
            return;
        }
        CurrentIndex++;
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
        if (followsPlayer && canFollowPlayer)
        {
            _navAgent.destination = SpawnBehave.player.position;
            return;
        }
        if ((_navAgent.remainingDistance <= _navAgent.stoppingDistance && !_navAgent.pathPending) || _navAgent.pathStatus == NavMeshPathStatus.PathInvalid)
            SetNextDestination(true);
        else if(_navAgent.isPathStale)
            SetNextDestination(false);
    }

}
