using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();
    // Start is called before the first frame update

    public int current = 0;

    public bool isLooped = true;

    private void PopulatePath()
    {
        waypoints.Clear();
        foreach(Transform child in transform.GetComponentsInChildren<Transform>())
        {
            if (child != transform)
            {
                waypoints.Add(child.position);
            }
        }
    }

    public void Awake()
    {
        PopulatePath();
    }

    public void OnDrawGizmos()
    {
        PopulatePath();
        Gizmos.color = Color.cyan;
        for(int i = 1 ; i < waypoints.Count ; i ++)
        {
            Gizmos.DrawLine(waypoints[i - 1], waypoints[i]);
            Gizmos.DrawSphere(waypoints[i-1], 1);
            Gizmos.DrawSphere(waypoints[i], 1);
            
        }

        if (isLooped)
        {
            Gizmos.DrawLine(waypoints[waypoints.Count - 1], waypoints[0]);

        }
    }

    public Vector3 Next()
    {
        return waypoints[current];
    }

    public bool IsLast()
    {
        return (current == waypoints.Count - 1);
    }
 
    public void AdvanceToNext()
    {
        if (! isLooped)
        {
            if (! IsLast())
            {
                current ++; 
            }
        }
        else
        {
            current = (current + 1) % waypoints.Count;
        }
    }
}