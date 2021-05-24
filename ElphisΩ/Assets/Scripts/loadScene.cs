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
           SceneManager.LoadScene(indexLvlToLoad); 
        }
        
    }

}
