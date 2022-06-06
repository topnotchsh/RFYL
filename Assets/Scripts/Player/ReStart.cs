using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    public void ReStartBtn()
    {
        SceneManager.LoadScene("Start");
    }

    public void QuitBtn()
	{
#if UNITY_EDITOR
    	UnityEditor.EditorApplication.isPlaying = false;
#else
    	Application.Quit();
#endif
    }
}
