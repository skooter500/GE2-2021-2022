using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : SteeringBehaviour
{
    public string foodTag = "Food";
    public float circleDistance = 10f;
    public float circleRadius = 5f;
    public float wanderJitter = 1f;
    public float wanderForce = 1f;

    private Vector3 wanderTarget;
    public Seek seek;
    public ObstacleAvoidance obstacleAvoidance;

    void Start()
    {
        wanderTarget = Random.insideUnitSphere * circleRadius;
        seek = GetComponent<Seek>();
        obstacleAvoidance = GetComponent<ObstacleAvoidance>();
    }

    public override Vector3 Calculate()
    {
        Vector3 force = Vector3.zero;

        // Calculate obstacle avoidance force
        Vector3 avoidanceForce = obstacleAvoidance.Calculate();

        // If the Seek script is active and enabled, and there's a food target
        if (seek.isActiveAndEnabled && seek.targetGameObject != null)
        {
            // Use the Seek script to calculate the steering force towards the food
            force += seek.Calculate() * seek.weight;
        }
        else
        {
            // Calculate wander force as before
            Vector3 circleCenter = boid.velocity.normalized * circleDistance;
            circleCenter.y = 0; // Restrict the Y axis

            wanderTarget += new Vector3(
                Random.Range(-1f, 1f) * wanderJitter,
                0, // Restrict the Y axis
                Random.Range(-1f, 1f) * wanderJitter);

            wanderTarget.Normalize();
            wanderTarget *= circleRadius;

            force = circleCenter + wanderTarget;
            force *= this.wanderForce;
        }

        // Apply the avoidance force
        force += avoidanceForce;

        return force;
    }

    public void OnCollisionEnter(Collider other)
    {
        Debug.Log("Collision Triggered");
        //if object has tab Food destroy object
        if (other.gameObject.CompareTag(foodTag))
        {
            Destroy(other.gameObject);
        }
    }
}