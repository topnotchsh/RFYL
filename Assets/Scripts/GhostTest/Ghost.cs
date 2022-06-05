using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Ghost : MonoBehaviour
{
    [Header("근접 거리")]
    [SerializeField] [Range(0f, 3f)] float contactDistance = 1f;

    [Header("추격 속도")]
    [SerializeField] [Range(1f, 4f)] float moveSpeed = 3f;

    [Header("카운트 다운")]
    [SerializeField] Text textCountdown;
    [SerializeField] Text guide;

    public int maxHealth;
    public int curHealth;
    public Transform target;

    NavMeshAgent nav;
    Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;
    Transform ghost;

    bool isChase; // 귀신 추격 이벤트 시작 
    bool isFound; // 사용자 공격 실패 시 true


    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponent<MeshRenderer>().material;
        nav = GetComponent<NavMeshAgent>();
        ghost = GetComponent<Transform>();
    }

    void Start()
    {
        textCountdown.gameObject.SetActive(false);
        guide.gameObject.SetActive(false);
        ghost.position = new Vector3(0, 0.7f, 0);
    }

    void Update()
    {
        ghost.localEulerAngles = new Vector3(0, 0, -180);

        if (isChase)
            nav.SetDestination(target.position);
    }

    void FreezeRotation()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    void FixedUpdate()  
    {
        FreezeRotation();
    }

    void ChaseStart()
    {
        // Vector3.Distance(transform.position, target.position) < contactDistance &&
        if (isFound)
        {
            // 플레이어가 귀신의 범위안에 들어옴
            // 5초 동안 대기 
            textCountdown.gameObject.SetActive(true);
            guide.gameObject.SetActive(true);
            StartCoroutine(CountDown());

            // 공격 성공 -> 귀신 파괴

            // 공격 실패 -> 추격 시작


        }
        else
        {
            rigid.velocity = Vector3.zero;
        }
    }

    IEnumerator CountDown()
    {
        int count = 5;
        while (count > 0)
        {
            Debug.Log(count);
            textCountdown.text = count.ToString();
            count--;
            yield return new WaitForSeconds(1);
        }


        if (count == 0)
        {
            textCountdown.gameObject.SetActive(false);
            guide.text = "귀신을 피해 도망가라."; 
            isChase = true;

        }
    }

    // 플레이어에게 공격받음
    void OnTriggerEnter(Collider collider)
    {
        isFound = true; // 플레이어 감지 

        if (collider.tag == "Player") // 플레이어 무기 감지
        {
            Debug.Log("Found!");
            ChaseStart();
            //curHealth -= 1;
            //StartCoroutine(OnDamage());
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
        {
            Debug.Log("Attack!");

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
