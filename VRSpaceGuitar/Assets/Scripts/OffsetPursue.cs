using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursue : SteeringBehaviour
{
    public Boid leader;
    Vector3 targetPos;
    Vector3 worldTarget;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - leader.transform.position;

        offset = Quaternion.Inverse(leader.transform.rotation) * offset;
    }

    // Update is called once per frame
    public override Vector3 Calculate()
    {
        worldTarget = leader.transform.TransformPoint(offset);
        float dist = Vector3.Distance(transform.position, worldTarget);
        float time = dist / boid.maxSpeed;

        targetPos = worldTarget + (leader.velocity * time);
        return boid.ArriveForce(targetPos);
    }
}
