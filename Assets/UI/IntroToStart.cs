using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroToStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GotoStart", 6f);
    }

    // Update is called once per frame
    void GotoStart()
    {
    	SceneManager.LoadScene(1);
    }
}
