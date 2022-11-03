using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * https://url.kr/42xkjp (참고 링크)
 */

public class HouseCameraCtrl : MonoBehaviour
{
    public GameObject player; //주인공 좌표를 위해 사용되는 변수

    //카메라가 움직일 수 있는 최소~최대 범위(수동으로 구함)
    public float minPosX = -5.3f;
    public float maxPosX = 5.3f;
    public float minPosY = -3.0f;
    public float maxPosY = 3.0f;


    private void Start() {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        //주인공 좌표
        float charX = player.transform.position.x;
        float charY = player.transform.position.y;

        //Clamp: 최대/최소값을 설정하여 float 값이 범위 이외의 값을 넘지 않도록 한다.
        float x = Mathf.Clamp(charX, minPosX, maxPosX);
        float y = Mathf.Clamp(charY, minPosY, maxPosY);

        //카메라의 좌표를 변경
        transform.position = new Vector3(x, y, -10);
    }
}
