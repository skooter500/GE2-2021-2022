using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicDetection : MonoBehaviour
{
    public int sampleWindow =64;
    private AudioClip microphoneClip;
    // Start is called before the first frame update
    void Start()
    {
        MicrophoneToAudioClip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MicrophoneToAudioClip()
    {
        string microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName,true,20,AudioSettings.outputSampleRate);
    }
    public float GetLoudnessFromMicrophone()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]),microphoneClip);
    }
    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition- sampleWindow;
        if(startPosition<0)
            return 0;

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData,startPosition);

        //compute loudness
        float totalLoudness = 0;
        for(int i = 0 ; i < sampleWindow; i++)
        {
            totalLoudness+= Mathf.Abs(waveData[i]);
        }
        return totalLoudness/ sampleWindow;
    }
}
