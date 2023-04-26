using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ParticleAIController : MonoBehaviour
{
    public Transform particleObj;
    protected NavMeshAgent otherParticleMesh;
    // Start is called before the first frame update
    void Start()
    {
        otherParticleMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        otherParticleMesh.SetDestination(particleObj.position);
    }
}
