using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;

public class Adjust_Video_Audio : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        //calculating volume
        float volume = PlayerPrefs.GetFloat("VideoVolume");
            volume = volume + 20;
            volume = volume/40;

        videoPlayer.SetDirectAudioVolume(0, volume);
    }
}
