using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;

public class Adjust_Video_Audio : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //calculating volume
        float volume = PlayerPrefs.GetFloat("VideoVolume");
        if(volume < 0){
            volume = volume+20;
            volume = volume/40;
        } else {
            volume = volume + 20;
            volume = volume/40;
        }

        videoPlayer.SetDirectAudioVolume(0, volume);
    }
}
