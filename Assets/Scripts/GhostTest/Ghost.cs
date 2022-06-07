using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    [Header("근접 거리")]
    [SerializeField] [Range(0f, 3f)] float contactDistance = 2f;

    [Header("추격 속도")]
    [SerializeField] [Range(1f, 4f)] float moveSpeed = 3f;

    [Header("카운트 다운")]
    [SerializeField] Text textCountdown;
    [SerializeField] Text guide;

    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public Transform player;

    public static int targetCount;
    public int playerCount;

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
        playerCount = 0;
        targetCount = 3;

        textCountdown.gameObject.SetActive(false);
        guide.gameObject.SetActive(false);

        target1.gameObject.SetActive(false);
        target2.gameObject.SetActive(false);
        target3.gameObject.SetActive(false);

        ghost.position = new Vector3(0, 0.7f, 0);
        // ghost.localEulerAngles = new Vector3(-180f, 0, 0);
    }

    void Update()
    {
        Vector3 delta = player.transform.position - transform.position;
        float dist = delta.magnitude;

        Quaternion rot = Quaternion.LookRotation(delta);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 5 * Time.deltaTime);

        if (isChase)
            nav.SetDestination(player.position);

        if(playerCount >= 2)
        {
            textCountdown.gameObject.SetActive(false);
            target1.gameObject.SetActive(false);
            target2.gameObject.SetActive(false);
            target3.gameObject.SetActive(false);
        }

        if(!target1 && !target2 && !target3)
        {
            Destroy(gameObject);
        }

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

            target1.gameObject.SetActive(true);
            target2.gameObject.SetActive(true);
            target3.gameObject.SetActive(true);

            StartCoroutine(CountDown());
        }
    }

    IEnumerator CountDown()
    {
        
        int count = 15;
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
            target1.gameObject.SetActive(false);
            target2.gameObject.SetActive(false);
            target3.gameObject.SetActive(false);

            guide.text = "귀신을 피해 도망가라.";

            isChase = true;

            int ghostCount = 2;
            while (ghostCount > 0)
            {
                ghostCount--;
                yield return new WaitForSeconds(1);
            }

            if (ghostCount == 0)
                isChase = true;
        }

        if (Vector3.Distance(transform.position, player.position) < contactDistance)
        {
            SceneManager.LoadScene("BadEnding");
        }

    }
        

    // 플레이어에게 공격받음
    void OnTriggerEnter(Collider collider)
    {
        isFound = true; // 플레이어 감지 

        if (collider.tag == "Player") // 플레이어 무기 감지
        {
            playerCount++;
            Debug.Log("Found!");
            ChaseStart();
        }

    }

    /*
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
    */


}
