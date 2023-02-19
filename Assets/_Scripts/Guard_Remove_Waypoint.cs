using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlazeAISpace;


public class Guard_Remove_Waypoint : MonoBehaviour
{
    // Start is called before the first frame update
    public BlazeAI _guard;


    void Start()
    {
       _guard = GetComponent<BlazeAI>();
       Debug.Log(_guard.waypoints.waypoints.Count);
        _guard.waypoints.waypoints.RemoveAt(_guard.waypoints.waypoints.Count - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
