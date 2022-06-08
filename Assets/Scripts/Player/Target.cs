using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject Player;
    public GameObject target;
    public Animator anim;

    private float delay = 1.0f;
    private float accumTime;
    public bool isDelay;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("IsAttack", false);
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

    public void OnTriggerEnter(Collider col){
        if(Player.tag == "Player"){
            if (Input.GetMouseButtonUp(0)){
                if(isDelay == false){
                    isDelay = true;
                    anim.SetBool("IsAttack", true);
                    Player.GetComponent<PlayerParams>().PlaySound("Attack");
                    Destroy(target);
                    Ghost.targetCount--;
                }
            }
        }
    }
}
