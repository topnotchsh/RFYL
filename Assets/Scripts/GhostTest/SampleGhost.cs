using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SampleGhost : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;
    public Transform target;
    public bool isChase;


    Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;
    NavMeshAgent nav;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponent<MeshRenderer>().material;
        nav = GetComponent<NavMeshAgent>();

        Invoke("ChaseStart", 2);
    }

    void ChaseStart()
    {
        isChase = true;        
    }

    void Update()
    {
        if (isChase)
            nav.SetDestination(target.position);
    }

    // 플레이어에게 공격받음
    void OnTriggerEnter(Collider other)
    {   
        if(other.tag == "Player")
        {
            Debug.Log("Ouch!");
            curHealth -= 3;
            StartCoroutine(OnDamage());
        }

    }

    IEnumerator OnDamage()
    {
        mat.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        if (curHealth > 0)
        {
            mat.color = Color.black;
        }
        else
        {
            mat.color = Color.gray;
            Destroy(gameObject, 1);
        }
    }

   
}
