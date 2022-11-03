using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick_moving : MonoBehaviour
{

    public Camera m_cam; // ī�޶�

    //Vector3 aim_screenPos;
    public RectTransform innerPad; //���� ��
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
        { //�̵�
            MoveControl();
        }
    }

    private void MoveControl()
    {
        Vector3 upMovement = Vector3.up * speed * Time.deltaTime * joystick.Vertical; //���Ϸ� �̵��ϴ� ����
        Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * joystick.Horizontal; //�¿�� �̵��ϴ� ����
        float stickAngle = Mathf.Abs(Mathf.Atan2(innerPad.anchoredPosition.x, innerPad.anchoredPosition.y) * Mathf.Rad2Deg); //���̽�ƽ ����

        this.transform.position += upMovement;
        this.transform.position += rightMovement;
    }
}
