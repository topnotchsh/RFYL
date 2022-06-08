using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator anim;
    public GameObject target;
    public GameObject player;

    public GameObject target11;
    public GameObject target12;
    public GameObject target13;

    public GameObject target21;
    public GameObject target22;
    public GameObject target23;

    public GameObject target31;
    public GameObject target32;
    public GameObject target33;

    public GameObject target41;
    public GameObject target42;
    public GameObject target43;

    public GameObject target51;
    public GameObject target52;
    public GameObject target53;

    public GameObject target61;
    public GameObject target62;
    public GameObject target63;

    public GameObject target71;
    public GameObject target72;
    public GameObject target73;

    public GameObject target81;
    public GameObject target82;
    public GameObject target83;

    private float delay = 1.0f;
    private float accumTime;
    public bool isDelay;

    //public SoundManager sm;

    // Start is called before the first frame update

    void Awake(){
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("IsAttack", false);
    }

    public void PlayerAttack(){
        target = GameObject.FindGameObjectWithTag("Target");

        if(isDelay == false){
            isDelay = true;
            anim.SetBool("IsAttack", true);
            player.GetComponent<PlayerParams>().PlaySound("Attack");
            Destroy(target);
            Ghost.targetCount--;
        }
        // if (Input.GetButton("Fire1")) {
            
        // }
        

    }


    // Update is called once per frame
    void Update()
    {
        if(isDelay){
            accumTime += Time.deltaTime;
            if (accumTime >= delay)
            {
                anim.SetBool("IsAttack", false);
                accumTime = 0.0f;
                isDelay = false;
                
            }
        }
    }
}
