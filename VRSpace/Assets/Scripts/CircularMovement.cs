using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    [SerializeField] Transform centerRotation;
    [SerializeField] float radiusRotation = 1f, angularSpeed = 3f;
    float posX, posZ,posY, angle = 0f;
    

    // Update is called once per frame
    void Update()
    {
        if (angle >= 360f)
            angle = 0f;
            posX =  centerRotation.position.x + Mathf.Cos (angle) * radiusRotation;
            posY =  centerRotation.position.y + Mathf.Sin (angle) * radiusRotation;
            posZ =  centerRotation.position.z + Mathf.Sin (angle) * radiusRotation;
            angle += Time.deltaTime * angularSpeed;
        

        transform.position = new Vector3(posX,posY,posZ);
    }
}
