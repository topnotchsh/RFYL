using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    // 마우스 회전
    public float turnSpeed = 4.0f; // 마우스 회전 속도
    private float xRotate = 0.0f; // 내부 사용할 X축 회전량은 별도 정의 ( 카메라 위 아래 방향 )
    public float moveSpeed = 4.0f; // 이동 속도
    //public float jumpForce = 10.0f; // 점프하는 힘
    private bool isGround = true; // 땅에 붙어있는가?
    Rigidbody body; // Rigidbody를 가져올 변수

    public float rot_speed = 100.0f;
    public GameObject Player;
    public GameObject MainCamera;

    private float camera_dist = 0f; //리그로부터 카메라까지의 거리
    public float camera_width = -10f; //가로거리
    public float camera_height = 4f; //세로거리
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        
        body = GetComponent<Rigidbody>(); // Rigidbody를 가져온다.
        transform.rotation = Quaternion.identity; // 회전 상태를 정면으로 초기화
        
        Player = GameObject.FindGameObjectWithTag("Player");
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        //카메라리그에서 카메라까지의 길이
        camera_dist = Mathf.Sqrt(camera_width * camera_width + camera_height * camera_height);
 
        //카메라리그에서 카메라위치까지의 방향벡터
        dir = new Vector3(0, camera_height, camera_width).normalized;
        
    }

    void FixedUpdate()
    {
        Move();
        //Jump();
    }

    void Move()
    {
        // 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 양 계산
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        // 현재 y축 회전값에 더한 새로운 회전각도 계산
        float yRotate = transform.eulerAngles.y + yRotateSize;

        // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향) 
        // Clamp 는 값의 범위를 제한하는 함수
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

        // 키보드에 따른 이동량 측정
        Vector3 move = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");

        // 이동량을 좌표에 반영
        transform.position += move * moveSpeed * Time.deltaTime;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * rot_speed, Space.World);
 
        transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * Time.deltaTime * rot_speed, Space.Self);
 
        //transform.position = Player.transform.position;
 
 
        //레이캐스트할 벡터값
        Vector3 ray_target = transform.up * camera_height + transform.forward * camera_width;
 
        RaycastHit hitinfo;
        Physics.Raycast(transform.position, ray_target, out hitinfo, camera_dist);
 
        if (hitinfo.point != Vector3.zero)//레이케스트 성공시
        {
            //point로 옮긴다.
            MainCamera.transform.position = hitinfo.point;
        }
        else
        {
            //로컬좌표를 0으로 맞춘다. (카메라리그로 옮긴다.)
            MainCamera.transform.localPosition = Vector3.zero;
            //카메라위치까지의 방향벡터 * 카메라 최대거리 로 옮긴다.
            //MainCamera.transform.Translate(dir * camera_dist);
 
        }
    }
}
