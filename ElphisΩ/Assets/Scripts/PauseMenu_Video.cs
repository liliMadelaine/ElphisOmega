using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PauseMenu_Video : MonoBehaviour
{
    private static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public Button pauseButton;
    public VideoPlayer videoPlayer;


    // Update is called once per frame
    void Update()
    {
        Button btn = pauseButton.GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
        if(GameIsPaused){
                Resume();
            } else {
                Pause();
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        videoPlayer.Play();
        GameIsPaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        videoPlayer.Pause();
        GameIsPaused = true;
    }

    public void loadMenue(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_0_MainMenu");
    }

    public void QuitGame(){
        Debug.Log("Game");
        Application.Quit();
    }

    public void SkipScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
