using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ammo;
    public GameObject health;

    public int total = 5;
    public int spawnRate = 2;

    public float spawnRadius = 20;

    public void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    System.Collections.IEnumerator Spawn()
    {
        while(true)
        {
            GameObject[] ammos = GameObject.FindGameObjectsWithTag("Ammo");
            if (ammos.Length < total)
            {
                GameObject a = GameObject.Instantiate(ammo);
                Vector2 position = Random.insideUnitCircle * spawnRadius;
                a.transform.position = new Vector3(position.x, 0, position.y);       
                a.transform.parent = this.transform;         
            }
            GameObject[] healths = GameObject.FindGameObjectsWithTag("Health");
            if (healths.Length < total)
            {
                GameObject h = GameObject.Instantiate(health);
                Vector2 position = Random.insideUnitCircle * spawnRadius;
                h.transform.position = new Vector3(position.x, 0, position.y);                
                h.transform.parent = this.transform;
            }
            yield return new WaitForSeconds( 1.0f / (float) spawnRate);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
