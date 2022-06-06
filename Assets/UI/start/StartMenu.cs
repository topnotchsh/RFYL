using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void OnClickStartGame()
    {
    	SceneManager.LoadScene(2);
    }

    public void OnClickQuit()
	{
#if UNITY_EDITOR
    	UnityEditor.EditorApplication.isPlaying = false;
#else
    	Application.Quit();
#endif
    }
}
