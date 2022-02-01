using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoid : MonoBehaviour
{

    public Path path;
    public bool pathFollowEnabled = false;

    public Vector3 acceleration;
    public Vector3 velocity;
    public Vector3 force;
    public float speed;
    public float mass = 1;
    public float maxSpeed = 10;

    public bool seekEnabled = true; 
    public Transform seekTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector3 Seek(Vector3 target)
    {
        Vector3 desired = (target - transform.position).normalized * maxSpeed;
        return desired - velocity;
    }

    public Vector3 PathFollow()
    {
        // This method generates a force that will explode the computer
        Vector3 nextWaypoint = path.Next();
        float dist = Vector3.Distance(nextWaypoint, transform.position);
        if (dist < 1.0f)
        {
            path.AdvanceToNext();
        }
        return Seek(nextWaypoint);
    }

    Vector3 Calculate()
    {
        force = Vector3.zero;
        if (seekEnabled)
        {
            force += Seek(seekTarget.position);
        }
        if (pathFollowEnabled)
        {
            force += PathFollow();
        }
        return force;
    }

    // Update is called once per frame
    void Update()
    {
        force = Calculate();
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        speed = velocity.magnitude;

        if (speed > 0)
        {
            transform.forward = velocity;
        }

    }
}
