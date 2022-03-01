using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{    
    public float radius = 10;
    public int numWaypoints = 5;
    public int current = 0;
    public List<Vector3> waypoints = new List<Vector3>();
    public Vector3[] waypoints;

    // public void Awake() 
    // {
    //     for(int i =0; i<=waypoints;i++)
    //     {
    //         waypoints.add(new Vector3(x,y,z));
    //     }
        
    // }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrawGizmos() 
    {
    //   waypoints.clear();   
    }
}
