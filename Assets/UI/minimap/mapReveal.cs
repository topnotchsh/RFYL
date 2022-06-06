using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapReveal : MonoBehaviour
{
    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("접촉");
        }
    }
}
