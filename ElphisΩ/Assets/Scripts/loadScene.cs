using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public int indexLvlToLoad;
    public string nameLvlToLoad;

    public bool useIntToLoadLvl;
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){

            GameObject thePlayer = GameObject.Find("Player");

            if(thePlayer != null){
                PlayerPrefs.SetInt("score", thePlayer.GetComponent<PlayerController>().currHealth);
            }
            

           SceneManager.LoadScene(indexLvlToLoad); 
        }
        
    }

}
