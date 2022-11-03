using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//주인공 애니메이션 설정 참고 링크: http://devkorea.co.kr/bbs/board.php?bo_table=m03_qna&wr_id=106646

public class PlayerJoystickMoving : MonoBehaviour {
    public RectTransform innerPad; //안쪽 원
    public float speed;

    private Joystick joystick;
    private Animator anim;

    void Awake() {
        this.transform.position = new Vector3(PlayerCtrlScript.playerX, PlayerCtrlScript.playerY, 0);

        joystick = GameObject.FindObjectOfType<Joystick>();
        anim = GetComponent<Animator>();
    }


    void FixedUpdate() {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0) { //이동
            anim.speed = 0.5f;
            MoveControl();
        } else { //이동 x
            anim.speed = 0.0f; //현재 재생 중인 애니메이션 멈춤
        }
    }

    private void MoveControl() {
        Vector3 upMovement = Vector3.up * speed * Time.deltaTime * joystick.Vertical; //상하로 이동하는 정도
        Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * joystick.Horizontal; //좌우로 이동하는 정도
        float stickAngle = Mathf.Abs(Mathf.Atan2(innerPad.anchoredPosition.x, innerPad.anchoredPosition.y) * Mathf.Rad2Deg); //조이스틱 각도

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