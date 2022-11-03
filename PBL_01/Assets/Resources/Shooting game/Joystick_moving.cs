using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick_moving : MonoBehaviour
{

    public Camera m_cam; // 카메라

    //Vector3 aim_screenPos;
    public RectTransform innerPad; //안쪽 원
    public float speed;

    private Joystick_shooting joystick;

    void Awake()
    {
        joystick = GameObject.FindObjectOfType<Joystick_shooting>();
    }


    void FixedUpdate()
    {
        //aim_screenPos = m_cam.WorldToScreenPoint(this.gameObject.transform.position);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        { //이동
            MoveControl();
        }
    }

    private void MoveControl()
    {
        Vector3 upMovement = Vector3.up * speed * Time.deltaTime * joystick.Vertical; //상하로 이동하는 정도
        Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * joystick.Horizontal; //좌우로 이동하는 정도
        float stickAngle = Mathf.Abs(Mathf.Atan2(innerPad.anchoredPosition.x, innerPad.anchoredPosition.y) * Mathf.Rad2Deg); //조이스틱 각도

        this.transform.position += upMovement;
        this.transform.position += rightMovement;
    }
}
