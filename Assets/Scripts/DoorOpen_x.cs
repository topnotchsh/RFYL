using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen_x : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            if (Input.GetButton("Fire1")){
                //animator.SetBool("IsOpen", true);
                transform.Translate(new Vector3(0.5f, 0, 0));
            }
        }
    }
}
