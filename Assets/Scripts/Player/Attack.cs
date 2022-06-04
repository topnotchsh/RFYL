using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator anim;
    public GameObject target;

    private float delay;
    private float IdleTime = 1f;
    // Start is called before the first frame update

    void Awake(){
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("IsAttack", false);
    }

    public void PlayerAttack(){
        // 귀신과 마주치면

        // 타겟 이미지를 n초 안에 클릭했으면
        //if (Input.GetButtonDown("Fire1"))
        
        anim.SetBool("IsAttack", true);
        //SoundManager.instance.AttackSound();
        Destroy(target);

        delay += Time.deltaTime;
        if (delay >= IdleTime)
        {
            anim.SetBool("IsAttack", false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
