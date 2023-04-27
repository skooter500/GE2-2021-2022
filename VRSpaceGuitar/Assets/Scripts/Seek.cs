using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Seek : SteeringBehaviour
{
    public GameObject targetGameObject = null;
    public Vector3 target = Vector3.zero;
    public float detectionRadius = 5.0f;

    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.cyan;
            if (targetGameObject != null)
            {
                target = targetGameObject.transform.position;
            }
            Gizmos.DrawLine(transform.position, target);
        }
    }
    
    public override Vector3 Calculate()
    {
        if (targetGameObject != null)
        {
            float distance = Vector3.Distance(transform.position, target);
            if (distance <= detectionRadius)
            {
                return boid.SeekForce(target);
            }
        }
        return Vector3.zero;
    }

    public void Update()
    {
        FindClosestFoodWithTag();
    }

    private void FindClosestFoodWithTag()
    {
        GameObject[] foodObjects = GameObject.FindGameObjectsWithTag("Food");
        float closestDistance = detectionRadius;
        GameObject closestFood = null;

        foreach (GameObject food in foodObjects)
        {
            float distance = Vector3.Distance(transform.position, food.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestFood = food;
            }
        }

        targetGameObject = closestFood;
        if (targetGameObject != null)
        {
            target = targetGameObject.transform.position;
        }
    }
}