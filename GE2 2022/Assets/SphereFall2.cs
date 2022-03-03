using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereFall2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    Vector3 finalV = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 0 && ! GetComponent<Rigidbody>().isKinematic)
        {
            Debug.Log(GetComponent<Rigidbody>().velocity);
            GetComponent<Rigidbody>().isKinematic = true;

        }
    }
}
