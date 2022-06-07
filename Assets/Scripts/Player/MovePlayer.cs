using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Camera mainCamera; //메인 카메라
    public int playerSpeed = 1;
    public bool isMoving;
    bool flag;

    float delay = 10.0f;
    float curTime;
    //public GameObject ghost;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = true;
        //flag = true;
        //ghost = GameObject.FindGameObjectWithTag("Ghost");
    }

    // Update is called once per frame
    void Update()
    {
        //if(ghost.isFound) isMoving = false;
        if(isMoving){
            transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        } else {
            transform.position = transform.position;
        }
        
    }

    //  private void OnTriggerEnter(Collider col)
    //  {
    //      if (col.gameObject.tag == "Ghost" && flag) {
    //         isMoving = false;
    //         curTime += Time.deltaTime;
    //         if(curTime >= delay){
    //             flag = false;
    //             isMoving = true;
    //             curTime = 0.0f;
    //         }
    //      }

    //  }
}
