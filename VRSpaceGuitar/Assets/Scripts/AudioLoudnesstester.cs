using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnesstester : MonoBehaviour
{
    // reference audio
    public AudioSource audioSource;

    // step update
    public float updateStep = 0.1f;

    //how long the array will be
    public int sampleDataLength = 1024;
    private float currentUpdateTime= 0f;

    //Loudness
    public float clipLoudness;
    private float[] clipSampleData;

    //game objects 
    public GameObject GameObj;

    //resposible for size of the object
    public float sizeFactor = 1;
    public float minSize = 0;
    public float maxSize = 500;

    private void Awake() {
        clipSampleData = new float[sampleDataLength];
    }
    private void Update() {
        currentUpdateTime += Time.deltaTime;
        //smooth the animation of the update
        if(currentUpdateTime >= updateStep)
        {
            currentUpdateTime =0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples);
            clipLoudness= 0f;
            //adjusts clipLoudness for each sample
            foreach( var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            //avrages object makes sure the object fits the game and limits the size
            clipLoudness /= sampleDataLength;
            clipLoudness *=sizeFactor;
            clipLoudness =Mathf.Clamp(clipLoudness,minSize,maxSize);


            // apply the scale to x y z
            GameObj.transform.localScale = new Vector3(clipLoudness,clipLoudness,clipLoudness);
        }
    }
}
