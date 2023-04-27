using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void start() 
    {
        //animator=GetComponent<Animator>();
    }
    void Update()
    {
        StartCoroutine(MoveCube());
    }

    // Update is called once per frame
    IEnumerator MoveCube()
    {
        animator.SetTrigger("Move");
        yield return null;
    }
}
