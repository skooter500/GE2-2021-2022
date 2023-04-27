using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Transform Character;
    public Animator animator;
    public Vector3 target = new Vector3(30,1,0);
    public float speed=1.0f;
    // Start is called before the first frame update
    void start() 
    {
        //animator=GetComponent<Animator>();
    }
    void Update()
    {
        StartCoroutine(MoveCube(target));
    }

    // Update is called once per frame
    IEnumerator MoveCube(Vector3 targetPosition)
    {
        transform.position= Vector3.Lerp(transform.position,targetPosition,1* Time.deltaTime);
        animator.SetTrigger("Move");
        yield return null;
    }
}
