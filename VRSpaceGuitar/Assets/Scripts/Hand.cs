using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private GameObject followObject;
    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private Vector3 posOffset;
    [SerializeField] private Vector3 rotateOffset;
    private Transform _followTarget;
    private Rigidbody _body;
    // Start is called before the first frame update
    void Start()
    {
        _followTarget = followObject.transform;
        _body = GetComponent<Rigidbody>();
        
        _body.interpolation = RigidbodyInterpolation.Interpolate;
        _body.mass=20f;

        _body.position = _followTarget.position;
        _body.rotation = _followTarget.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        PhysicsMove();
    }
    

    private void PhysicsMove()
    {
        var posWithOffset =  _followTarget.TransformPoint(posOffset);
        var distance = Vector3.Distance(posWithOffset, transform.position);
        _body.velocity = (posWithOffset - transform.position).normalized * (followSpeed * distance);

        var rotateWithOffset = _followTarget.rotation * Quaternion.Euler(rotateOffset);
        var q =  rotateWithOffset * Quaternion.Inverse(_body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
    }
}
