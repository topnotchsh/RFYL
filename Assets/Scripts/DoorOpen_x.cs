using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen_x : MonoBehaviour
{
    public GameObject Door;
    public GameObject Player;
    Vector3 DoorPos;
    Vector3 newPos;
    //Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        DoorPos = Door.transform.position;
    
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
                //transform.Translate(new Vector3(0.5f, 0, 0), Space.World);
                //Door.transform.position += new Vector3(0,0,1);
                //Door.transform.position = new Vector3(x, y, z);
                //Door.transform.position(newPos);
                //Door.transform.Rotate(new Vector3(0, 90, 0));
                Destroy(Door);
                Debug.Log("transform door");
            }
        }
    }
}
