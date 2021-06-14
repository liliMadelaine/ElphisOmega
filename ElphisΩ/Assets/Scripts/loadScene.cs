using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public int nextLvl;
    //public string nameLvlToLoad;
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
           SceneManager.LoadScene(nextLvl); 
        }
        
    }

}
