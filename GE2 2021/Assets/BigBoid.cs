using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoid : MonoBehaviour
{
    
    public Vector3 velocity;
    public float speed;
    public Vector3 acceleration;
    public Vector3 force;
    public float maxSpeed = 5;
    public float maxForce = 10;

    public float mass = 1;

    public bool seekEnabled = true;
    public Transform seekTargetTransform;
    public Vector3 seekTarget;

    public bool arriveEnabled = false;
    public Transform arriveTargetTransform;
    public Vector3 arriveTarget;
    public float slowingDistance = 80;

    public Path path;
    public bool pathFollowingEnabled = false;
    public float waypointDistance = 3;

    // Banking
    public float banking = 0.1f; 

    public float damping = 0.1f;

    public bool playerSteeringEnabled = false;
    public float steeringForce = 100;

    public bool pursueEnabled = false;
    public BigBoid pursueTarget;

    public Vector3 pursueTargetPos; 

    public bool offsetPursueEnabled = false;
    public BigBoid leader;
    public Vector3 offset;
    private Vector3 worldTarget;
    private Vector3 targetPos;

    public Vector3 Pursue(BigBoid pursueTarget)
    {
        float dist = Vector3.Distance(pursueTarget.transform.position, transform.position);
        float time = dist / maxSpeed;
        pursueTargetPos = pursueTarget.transform.position 
                    + pursueTarget.velocity * time;
        return Seek(pursueTargetPos);
    }


    public void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        //Gizmos.DrawLine(transform.position, transform.position + velocity);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + acceleration);

        Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position, transform.position + force * 10);

        if (arriveEnabled)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(arriveTargetTransform.position, slowingDistance);
        }

        if (pursueEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, pursueTargetPos);
        }

    }

    public Vector3 OffsetPursue(BigBoid leader)
    {
        worldTarget = leader.transform.TransformPoint(offset);
        float dist = Vector3.Distance(transform.position, worldTarget);
        float time = dist / maxSpeed;

        targetPos = worldTarget + (leader.velocity * time);
        return Arrive(targetPos);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (offsetPursueEnabled)
        {
            offset = transform.position - leader.transform.position;
        }
    }

    public Vector3 PlayerSteering()
    {
        Vector3 force = Vector3.zero;
        force += Input.GetAxis("Vertical") * transform.forward * steeringForce;

        Vector3 projected = transform.right;
        projected.y = 0;
        projected.Normalize();

        force += Input.GetAxis("Horizontal") * projected * steeringForce;

        // Put your code here!
        return force;
    }

    public Vector3 PathFollow()
    {
        Vector3 nextWaypoint = path.Next();
        if (!path.isLooped && path.IsLast())
        {
            return Arrive(nextWaypoint);
        }
        else
        {
            if (Vector3.Distance(transform.position, nextWaypoint) < waypointDistance)
            {
                path.AdvanceToNext();
            }
            return Seek(nextWaypoint);
        }
    }

    public Vector3 Seek(Vector3 target)
    {
        Vector3 toTarget = target - transform.position;
        Vector3 desired = toTarget.normalized * maxSpeed;

        return (desired - velocity);
    } 

    public Vector3 Arrive(Vector3 target)
    {
       Vector3 toTarget = target - transform.position;
       float dist = toTarget.magnitude;
       float ramped = (dist / slowingDistance) * maxSpeed;
       float clamped = Mathf.Min(ramped, maxSpeed);
       Vector3 desired = clamped * (toTarget / dist);
       return desired - velocity;
    }

    public Vector3 CalculateForce()
    {
        Vector3 f = Vector3.zero;
        if (seekEnabled)
        {
            if (seekTargetTransform != null)
            {
                seekTarget = seekTargetTransform.position;
            }
            f += Seek(seekTarget);
        }

        if (arriveEnabled)
        {
            if (arriveTargetTransform != null)
            {
                arriveTarget = arriveTargetTransform.position;                
            }
            f += Arrive(arriveTarget);
        }

        if (pathFollowingEnabled)
        {
            f += PathFollow();
        }

        if (playerSteeringEnabled)
        {
            f += PlayerSteering();
        }

        if (pursueEnabled)
        {
            f += Pursue(pursueTarget);
        }

        if (offsetPursueEnabled)
        {
            f += OffsetPursue(leader);
        }

        return f;
    }

    // Update is called once per frame
    void Update()
    {
        force = CalculateForce();
        acceleration = force / mass;
        velocity = velocity + acceleration * Time.deltaTime;
        transform.position = transform.position + velocity * Time.deltaTime;
        speed = velocity.magnitude;
        if (speed > 0)
        {
            //transform.forward = velocity;
            Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (acceleration * banking), Time.deltaTime * 3.0f);
            transform.LookAt(transform.position + velocity, tempUp);

            //velocity *= 0.9f;

            // Remove 10% of the velocity every second
            velocity -= (damping * velocity * Time.deltaTime);
        }        
    }
}
