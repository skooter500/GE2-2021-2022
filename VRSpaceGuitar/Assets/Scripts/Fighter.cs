using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public float health = 10;
    public float ammo = 10;
    
    public GameObject bullet;
    public GameObject enemy;
    public TMPro.TextMeshPro text;

    void Start()
    {
    }

    void Update()
    {                
        text.text = "Health: " + health + "\n" + 
            
            "Ammo: " + ammo + "\n" +
            "State: " + GetComponent<StateMachine>().currentState.GetType().Name + "\n" +
            "Global State: " + GetComponent<StateMachine>().globalState.GetType().Name;

    }
}