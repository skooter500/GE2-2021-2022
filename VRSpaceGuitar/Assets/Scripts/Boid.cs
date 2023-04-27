using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    List<SteeringBehaviour> behaviours = new List<SteeringBehaviour>();

    public Vector3 force = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;
    public Vector3 velocity = Vector3.zero;
    public float mass = 1;

    [Range(0.0f, 10.0f)]
    public float damping = 0.01f;

    [Range(0.0f, 1.0f)]
    public float banking = 0.1f;
    public float maxSpeed = 5.0f;
    public float maxForce = 10.0f;
    private float initialY;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + velocity);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + force * 10);
    }

    // Use this for initialization
    void Start()
    {

        SteeringBehaviour[] behaviours = GetComponents<SteeringBehaviour>();
         initialY = transform.position.y;

        foreach (SteeringBehaviour b in behaviours)
        {
            this.behaviours.Add(b);            
        }
    }

    public Vector3 SeekForce(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= maxSpeed;
        return desired - velocity;
    }

    public Vector3 ArriveForce(Vector3 target, float slowingDistance = 10.0f,float  decelleration = 3)
    {
        Vector3 toTarget = target - transform.position;

        float distance = toTarget.magnitude;
        Vector3 desired;
        if (distance < slowingDistance)
        {
            desired = maxSpeed * (distance / slowingDistance) * (toTarget / distance);
        }
        else
        {
            desired = maxSpeed * (toTarget / distance);
            decelleration = 1;
        }    

        return desired - velocity * decelleration;
    }
    

    Vector3 Calculate()
    {
        force = Vector3.zero;

        // Weighted prioritised truncated running sum
        // 1. Behaviours are weighted
        // 2. Behaviours are prioritised
        // 3. Truncated
        // 4. Running sum

        foreach(SteeringBehaviour b in behaviours)
        {
            if (b.isActiveAndEnabled)
            {
                force += b.Calculate() * b.weight;
                float f = force.magnitude;
                if (f > maxForce)
                {
                    force = Vector3.ClampMagnitude(force, maxForce);
                    break;
                }
            }
        }

        

        return force;
    }


    // Update is called once per frame
    void Update()
    {
        force = Calculate();
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        if (velocity.magnitude > 0)
        {
            Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (acceleration * banking), Time.deltaTime * 3.0f);
            transform.LookAt(transform.position + velocity, tempUp);

            // Lock X and Z rotations
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

            // Update position
            transform.position += velocity * Time.deltaTime;
            // Set the Y position to the initial Y value
            transform.position = new Vector3(transform.position.x, initialY, transform.position.z);

            velocity *= (1.0f - (damping * Time.deltaTime));
        }
    }
    public void ApplyForce(Vector3 additionalForce)
    {
        force += additionalForce;
    }
}
