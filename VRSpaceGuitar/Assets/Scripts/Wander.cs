using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : SteeringBehaviour
{
    public float circleDistance = 10f;
    public float circleRadius = 5f;
    public float wanderJitter = 1f;
    public float wanderForce = 1f;

    private Vector3 wanderTarget;

    void Start()
    {
        wanderTarget = Random.insideUnitSphere * circleRadius;
    }

    public override Vector3 Calculate()
    {
        Vector3 circleCenter = boid.velocity.normalized * circleDistance;
        circleCenter.y = 0; // Restrict the Y axis

        wanderTarget += new Vector3(
            Random.Range(-1f, 1f) * wanderJitter,
            0, // Restrict the Y axis
            Random.Range(-1f, 1f) * wanderJitter);

        wanderTarget.Normalize();
        wanderTarget *= circleRadius;

        Vector3 wanderForce = circleCenter + wanderTarget;
        wanderForce *= this.wanderForce;

        // Add obstacle avoidance force
        Vector3 avoidanceForce = boid.GetComponent<ObstacleAvoidance>().Calculate();

        // Weight the forces
        wanderForce *= weight;
        avoidanceForce *= weight;

        // Apply the forces
        boid.ApplyForce(wanderForce);
        boid.ApplyForce(avoidanceForce);

        // Return the total force
        return wanderForce + avoidanceForce;
    }
}
