using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Camera mainCamera; //메인 카메라
    public int moveSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 dir = new Vector3(hit.point.x - transform.position.x, 0f, hit.point.z - transform.position.z); //방향 구하기
            //curr_speed = Mathf.Clamp(curr_speed += aclrt * Time.deltaTime, 0f, maxSpeed); //가속
            transform.rotation = Quaternion.LookRotation(dir); //방향 설정
        }
        //curr_speed = Mathf.Clamp(curr_speed -= aclrt* Time.deltaTime, 0f, maxSpeed); //감속
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);


        //transform.position = transform.position + Camera.main.transform.forward * moveSpeed * Time.deltaTime;
    }


}
