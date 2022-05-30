using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text playerTalisman;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void UpdatePlayerUI(PlayerParams playerParams)
    {
        playerTalisman.text = "x " + playerParams.talisman.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
