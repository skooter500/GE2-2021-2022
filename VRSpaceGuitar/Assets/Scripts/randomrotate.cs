using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomrotate : MonoBehaviour
{
    [Range(0, 360)]
    public float speed = 90;
    private float rotateS;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rotateS = speed * Time.deltaTime;
        transform.Rotate(0, rotateS, 0);
    }
}
