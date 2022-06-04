using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator anim;
    public GameObject target;

    private float delay = 1.0f;
    private float accumTime;
    public bool isDelay;

    // Start is called before the first frame update

    void Awake(){
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("IsAttack", false);
    }

    public void PlayerAttack(){
        // 귀신과 마주치면

        // 타겟 이미지를 n초 안에 클릭했으면
        //if (Input.GetButtonDown("Fire1"))
        
        if(isDelay == false){
            isDelay = true;
            anim.SetBool("IsAttack", true);
            //SoundManager.instance.AttackSound();
            Destroy(target);

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
