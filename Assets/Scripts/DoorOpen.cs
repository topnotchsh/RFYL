﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //void OnTriggerEnter(Colider other){
    //    if(other.tag == 'Player'){
    //        animator.SetBool("IsOpen", true);
    //    }
    //}
}
