using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    
    void Awake(){
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            //float volume = (PlayerPrefs.GetFloat("VideoVolume") + 20)/ 40;
            s.source.volume = 1f;
            s.source.loop = s.loop;
        }
    }

    public void Play (string title){
        Sound s = Array.Find(sounds, sound => sound.title == title);
        if(s == null){
            Debug.LogWarning("Sound wasn't found.");
            return;
        }
        s.source.Play();
    } 
}
