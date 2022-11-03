using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * https://url.kr/42xkjp (���� ��ũ)
 */

public class HouseCameraCtrl : MonoBehaviour
{
    public GameObject player; //���ΰ� ��ǥ�� ���� ���Ǵ� ����

    //ī�޶� ������ �� �ִ� �ּ�~�ִ� ����(�������� ����)
    public float minPosX = -5.3f;
    public float maxPosX = 5.3f;
    public float minPosY = -3.0f;
    public float maxPosY = 3.0f;


    private void Start() {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        //���ΰ� ��ǥ
        float charX = player.transform.position.x;
        float charY = player.transform.position.y;

        //Clamp: �ִ�/�ּҰ��� �����Ͽ� float ���� ���� �̿��� ���� ���� �ʵ��� �Ѵ�.
        float x = Mathf.Clamp(charX, minPosX, maxPosX);
        float y = Mathf.Clamp(charY, minPosY, maxPosY);

        //ī�޶��� ��ǥ�� ����
        transform.position = new Vector3(x, y, -10);
    }
}
