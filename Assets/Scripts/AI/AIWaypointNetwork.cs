using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum DisplayMode { None, Connections, Paths}
public class AIWaypointNetwork : MonoBehaviour 
{ 

    [HideInInspector] public int UIStart;
    [HideInInspector] public int UIEnd;
	public List<Transform> Waypoints = new List<Transform>();

}
