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

    /*private void OnTriggerEnter2D(Collider2D collision) {

        GameObject collissionGameObject = collision.gameObject;

        if(collision.tag == "Player"){
           LoadScene(); 
        }

        
    }

    void LoadScene(){
        if(useIntToLoadLvl){
            SceneManager.LoadScene(indexLvlToLoad);
        } else {
            SceneManager.LoadScene(nameLvlToLoad);
        }
        
    }
    */

}
