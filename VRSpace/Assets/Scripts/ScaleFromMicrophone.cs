using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFromMicrophone : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public MicDetection detector;
    public float loudnessSensibility = 100;
    public float threshold = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if ( loudness<threshold)
            loudness =0;
        transform.localScale= Vector3.Lerp(minScale,maxScale,loudness);
    }
}
