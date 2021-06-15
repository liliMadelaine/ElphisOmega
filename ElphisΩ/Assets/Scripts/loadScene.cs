using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public int nextLvl;

    void OnTriggerEnter2D(Collider2D other) {
            
        if(other != null){
        PlayerPrefs.SetInt("score", other.GetComponent<PlayerController>().currHealth);
        }
        
        SceneManager.LoadScene(nextLvl); 
    }

}
