using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if(Talisman.numTalis >= 20){
            SceneManager.LoadScene("HappyEnding");
        } else {
            SceneManager.LoadScene("BadEnding");
        }
        
    }
}
