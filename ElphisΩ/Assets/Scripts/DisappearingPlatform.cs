using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{   
    private void OnCollisionEnter2D (Collision2D other){
        if(other.gameObject.tag == "Player"){
            StartCoroutine(Waiting());
        }        
    }

    IEnumerator Waiting(){
        yield return new WaitForSeconds(.01f);
        Destroy(this.gameObject);
    }
}
