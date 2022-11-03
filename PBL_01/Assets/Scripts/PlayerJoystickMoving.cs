using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ΰ� �ִϸ��̼� ���� ���� ��ũ: http://devkorea.co.kr/bbs/board.php?bo_table=m03_qna&wr_id=106646

public class PlayerJoystickMoving : MonoBehaviour {
    public RectTransform innerPad; //���� ��
    public float speed;

    private Joystick joystick;
    private Animator anim;

    void Awake() {
        this.transform.position = new Vector3(PlayerCtrlScript.playerX, PlayerCtrlScript.playerY, 0);

        joystick = GameObject.FindObjectOfType<Joystick>();
        anim = GetComponent<Animator>();
    }


    void FixedUpdate() {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0) { //�̵�
            anim.speed = 0.5f;
            MoveControl();
        } else { //�̵� x
            anim.speed = 0.0f; //���� ��� ���� �ִϸ��̼� ����
        }
    }

    private void MoveControl() {
        Vector3 upMovement = Vector3.up * speed * Time.deltaTime * joystick.Vertical; //���Ϸ� �̵��ϴ� ����
        Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * joystick.Horizontal; //�¿�� �̵��ϴ� ����
        float stickAngle = Mathf.Abs(Mathf.Atan2(innerPad.anchoredPosition.x, innerPad.anchoredPosition.y) * Mathf.Rad2Deg); //���̽�ƽ ����

        transform.position += upMovement;
        transform.position += rightMovement;


        //Front: 0, Left: 1, Back: 2, Right: 3
        if(stickAngle < 45f) {
            anim.SetInteger("direction", 2);
        } else if(stickAngle >135f) {
            anim.SetInteger("direction", 0);
        } else {
            if(joystick.Horizontal < 0) anim.SetInteger("direction", 1);
            else anim.SetInteger("direction", 3);
        }
    }
}