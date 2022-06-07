using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject Door;
    public GameObject Player;
    //Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other){
        if(Player.tag == "Player"){
            if (Input.GetMouseButtonUp(0)){
                //animator.SetBool("IsOpen", true);
                Door.transform.Translate(new Vector3(0, 0, -0.5f));
            }
        }
    }
}
