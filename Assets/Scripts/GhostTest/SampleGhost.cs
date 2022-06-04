using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SampleGhost : MonoBehaviour
{
    [Header("���� �Ÿ�")]
    [SerializeField] [Range(0f, 3f)] float contactDistance = 1f;

    public int maxHealth;
    public int curHealth;
    public Transform target;
    
    NavMeshAgent nav;
    Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;
    Transform ghost;

    bool isChase; // �ͽ� �߰� �̺�Ʈ ���� 
    bool isFound; // ����� ���� ���� �� true


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
        ghost.position = new Vector3(0, 0.7f, 0);
    }

    void Update()
    {        
        ghost.localEulerAngles = new Vector3(0, 0, -180);
        ChaseStart();

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
        if (Vector3.Distance(transform.position, target.position) < contactDistance && isFound)
        {
            // �÷��̾ �ͽ��� �����ȿ� ����
            // 5�� ���� ��� 
            StartCoroutine("CountDown");
            // ���� ���� -> �ͽ� �ı�
            StartCoroutine(OnDamage());
            // ���� ���� -> �߰� ����
            isChase = true;
        }
        else
        {
            rigid.velocity = Vector3.zero;
        }        
    }

    IEnumerator CountDown()
    {
        int count = 5;
        while(count > 0)
        {
            Debug.Log(count);
            count--;
        }
        yield return new WaitForSeconds(1);
    }

    // �÷��̾�� ���ݹ���
    void OnTriggerEnter(Collider collider)
    {
        isFound = true; // �÷��̾� ���� 

        if(collider.tag == "Player") // �÷��̾� ���� ����
        {
            Debug.Log("Found!");
            //curHealth -= 1;
            //StartCoroutine(OnDamage());
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Cube")
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
