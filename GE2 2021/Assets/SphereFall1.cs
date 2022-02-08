using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereFall1 : MonoBehaviour
{
    public float time;
    Vector3 gravity = new Vector3(0, -9.8f, 0);
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 0)
        {
            velocity += gravity * Time.deltaTime;
            time += Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
        }
    }
}
