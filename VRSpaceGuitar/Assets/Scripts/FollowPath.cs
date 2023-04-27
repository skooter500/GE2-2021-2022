using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : SteeringBehaviour {

    public Path path;

    Vector3 nextWaypoint;

    public float waypointDistance = 5;

    public int next = 0;
    public bool looped = true;


    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, nextWaypoint);
        }
    }

    public Vector3 NextWaypoint()
    {
        return path.waypoints[next];
    }

    public void AdvanceToNext()
    {
        if (looped)
        {
            next = (next + 1) % path.waypoints.Count;
        }
        else
        {
            if (next != path.waypoints.Count - 1)
            {
                next++;
            }
        }
    }

    public bool IsLast()
    {
        return next == path.waypoints.Count - 1;
    }


    public override Vector3 Calculate()
    {
        nextWaypoint = NextWaypoint();
        if (Vector3.Distance(transform.position, nextWaypoint) < waypointDistance)
        {
            AdvanceToNext();
        }

        if (!looped && IsLast())
        {
            return boid.ArriveForce(nextWaypoint);
        }
        else
        {
            return boid.SeekForce(nextWaypoint);
        }
    }
}
