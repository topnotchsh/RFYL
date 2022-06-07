using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen_x : MonoBehaviour
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
        Debug.Log("call OnTriggerEnter");
        if(Player.tag == "Player"){
            Debug.Log("player tag");
            if (Input.GetMouseButtonUp(0)){
                Debug.Log("get button");
                //animator.SetBool("IsOpen", true);
                Door.transform.Translate(new Vector3(0.5f, 0, 0)* Time.deltaTime);
                //Door.transform.position = Door.transform.position + new Vector3(0.5f, 0, 0);
                //Door.transform.Rotate(new Vector3(0, 90, 0));
                Debug.Log("transform door");
            }
        }
    }
}
