using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public Button pauseButton;


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
        GameIsPaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
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
}
