using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorController : MonoBehaviour
{
    
    public void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Bullet")
        {
            if (GetComponent<Fighter>().health > 0)
            {
                GetComponent<Fighter>().health --;
            }
            Destroy(c.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<StateMachine>().ChangeState(new AttackState());        
        GetComponent<StateMachine>().SetGlobalState(new Alive());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
