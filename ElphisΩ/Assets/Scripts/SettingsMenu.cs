using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start(){
        //resolutions = Screen.resolutions;
        Resolution[] screen = Screen.resolutions;

        int index = -1;
        Resolution[] temp = new Resolution[screen.Length];
        for(int i = 0; i < screen.Length; i++) {
             if(screen[i].height * 1.7777 <= screen[i].width){
                 index++;
                 temp[index] = screen[i];
             }
        }

        index++;
        resolutions = new Resolution[(index)];
        for(int i = 0; i < resolutions.Length; i++) {
                resolutions[i] = temp[i];
        }


        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++) {

                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);

                if( resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height){
                    
                    currentResolutionIndex = i;
                }  
        }

        if(currentResolutionIndex == 0) currentResolutionIndex = 0;

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void setResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
}
