using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKFootSolver : MonoBehaviour
{
    //Serialized fields 
    [SerializeField] private LayerMask terrainLayer;
    [SerializeField] private Transform body;
    [SerializeField] private IKFootSolver otherFoot;
    [SerializeField] private float speed = 2, stepDistance = .3f, stepLength =.3f, stepHeight = .3f;
    [SerializeField] private Vector3 footPosOffset, footRotOffset; 

    //variables not to be displayed therefore _
    private float _footspacing, _lerp; 
    private Vector3 _oldPosition, _currentPos, _newPosition;
    private Vector3 _oldNormal, _currentNorm, _newNormal;
    private bool _isFirstStep = true;

    // Start is called before the first frame update
    void Start()
    {
        //start position
        _footspacing = transform.localPosition.x;
        _currentPos = _newPosition = _oldPosition = transform.position;
        _currentNorm= _newNormal = _oldNormal = transform.up;
        _lerp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=_currentPos + footPosOffset;
        transform.rotation = Quaternion.LookRotation(_currentNorm) * Quaternion.Euler(footRotOffset);
        Ray ray = new Ray( body.position +(body.right * _footspacing) + (Vector3.up *2), Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit , 10 ,terrainLayer.value))
        {

            if(_isFirstStep || (Vector3.Distance(_newPosition, hit.point) > stepDistance && !otherFoot.IsCharMoving() && !IsCharMoving()))
            {
                _isFirstStep= false;
                _lerp = 0;
                int direction =body.InverseTransformPoint(hit.point).z > body.InverseTransformPoint(_newPosition).z
                    ? 1
                    : -1;
                _newPosition =  hit.point + (body.forward * (direction * stepLength));
                _newNormal = hit.normal ;
            }
        }
        if(_lerp<1)
        {
            Vector3 tempPos = Vector3.Lerp(_oldPosition,_newPosition,_lerp);
            tempPos.y += Mathf.Sin(_lerp * Mathf.PI) * stepHeight;

            _currentPos=tempPos;
            _currentNorm= Vector3.Lerp(_oldNormal,_newNormal,_lerp);
            _lerp += Time.deltaTime * speed;
        }
        else
        {
            _oldPosition = _newPosition;
            _oldNormal = _newNormal;
        }
    }

    //Checks if character is moving
    public bool IsCharMoving()
    {
        return _lerp <1;
    }


    //Test where the step is 
    private void OnDrawGizmos() {
        Gizmos.color=  Color.blue;
        Gizmos.DrawSphere(_newPosition,0.1f);
    }
}
