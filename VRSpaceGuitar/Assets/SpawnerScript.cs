using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    GameObject CharLegs;
    GameObject CharHead;
    GameObject CharArms;
    GameObject CharChest;

    public GameObject[] LegsPrefab;
    public GameObject[] HeadPrefab;
    public GameObject[] ArmsPrefab;
    public GameObject[] ChestPrefab;

    public GameObject CharContainer;
    // Start is called before the first frame update
    void Start()
    { 
        SpawnCharacter();
    }
    public void SpawnCharacter()
    {
        var NumSelect= 0;
        NumSelect  = Random.Range(0, 9);
        CharContainer.transform.position = new Vector3(-5.0f, 1.0f, 0f);
        CharLegs = (GameObject)Instantiate(LegsPrefab[1]);
        CharHead = (GameObject)Instantiate(HeadPrefab[1]);
        CharArms = (GameObject)Instantiate(ArmsPrefab[1]);
        CharChest = (GameObject)Instantiate(ChestPrefab[1]);
        
        CharLegs.transform.SetParent(CharContainer.transform);
        CharHead.transform.SetParent(CharContainer.transform);
        CharArms.transform.SetParent(CharContainer.transform);
        CharChest.transform.SetParent(CharContainer.transform);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
