using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator anim;
    public GameObject target;
    public GameObject player;

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
