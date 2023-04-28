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
<<<<<<< Updated upstream

=======
    private Dictionary<string, List<GameObject>> collectedBodyParts = new Dictionary<string, List<GameObject>>();
    public Transform bodyPartContainer; // The container for attached body parts
    public AudioSource Player;

    public GameObject oldBodyHead;
    public GameObject oldBodyChest;
    public GameObject oldBodyArms;
    public GameObject oldBodyLegs;
    public GameObject CharContainer;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======

    void EatFood(string bodyPart, GameObject prefab)
    {
        if (!collectedBodyParts.ContainsKey(bodyPart))
        {
            collectedBodyParts.Add(bodyPart, new List<GameObject>());
        }

        collectedBodyParts[bodyPart].Add(prefab);

        if (collectedBodyParts[bodyPart].Count >= 4)
        {
            // Output the name of the body part being attached
            Debug.Log("4 " + bodyPart + "s collected. Adding " + prefab.name + " to the creature.");

            // Attach the body part to the creature
            AttachBodyPart(bodyPart, prefab);

            // Empty the collected body parts list for this body part type
            collectedBodyParts[bodyPart].Clear();
        }
    }

    void AttachBodyPart(string bodyPart, GameObject prefab)
    {
        // Find body parts using tags
        oldBodyHead = GameObject.Find("head");
        oldBodyChest = GameObject.FindWithTag("Chest");
        oldBodyArms = GameObject.FindWithTag("Arms");
        oldBodyLegs = GameObject.FindWithTag("Legs");
    
        // Insantiate new body part using prefab
        GameObject newBodyPart = Instantiate(prefab, bodyPartContainer);

        // find new body part with tags transform the position of new body part and destroy the old
        if (newBodyPart.tag == "head")
        {
            
            newBodyPart.transform.localPosition = oldBodyHead.transform.position;

            // Set Parent to the container box
            newBodyPart.transform.SetParent(CharContainer.transform);
            
            // Set the right look rotation
            newBodyPart.transform.localRotation = Quaternion.identity;  

            Player = newBodyPart.GetComponent<AudioSource>();
            playChord();
            Destroy(oldBodyHead); 
        }
        if (newBodyPart.tag == "Chest")
        {
            newBodyPart.transform.localPosition = oldBodyChest.transform.position;

            // Set Parent to the container box
            newBodyPart.transform.SetParent(CharContainer.transform);
            // Set the right look rotation
            newBodyPart.transform.localRotation = Quaternion.identity;            
            Destroy(oldBodyChest);
        }
        if (newBodyPart.tag == "Arms")
        {
            newBodyPart.transform.localPosition = oldBodyArms.transform.position;

            // Set Parent to the container box
            newBodyPart.transform.SetParent(CharContainer.transform);
            // Set the right look rotation
            newBodyPart.transform.localRotation = Quaternion.identity;
            Destroy(oldBodyArms);
        }
        if (newBodyPart.tag == "Legs")
        {
            newBodyPart.transform.localPosition = oldBodyLegs.transform.position;

            // Set Parent to the container box
            newBodyPart.transform.SetParent(CharContainer.transform);
            // Set the right look rotation
            newBodyPart.transform.localRotation = Quaternion.identity;
            Destroy(oldBodyLegs);
        }



    }

    public void playChord()
    {
        Player.Play();
    }
>>>>>>> Stashed changes
}