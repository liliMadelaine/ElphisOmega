using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class video : MonoBehaviour
{
    //public float wait_for;
    public VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(WaitForIntroVideo());
        videoPlayer.loopPointReached += LoadScene;
    }

    void LoadScene(VideoPlayer vp){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
