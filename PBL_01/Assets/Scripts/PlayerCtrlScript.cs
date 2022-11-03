using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�ٸ� ���� ���ٰ� ���ƿ��� ��, ���ΰ��� ��ġ�� ������Ű�� ���� ��ũ��Ʈ

public class PlayerCtrlScript : MonoBehaviour
{
    static public float playerX = 0.0f;
    static public float playerY = 0.0f;
    private GameObject player;

    private void Awake() {
        player = GameObject.Find("Player");
        var obj = FindObjectsOfType<PlayerCtrlScript>();

        if (obj.Length == 1) {
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "House") {
            player = GameObject.Find("Player");
            playerX = player.transform.position.x;
            playerY = player.transform.position.y;
        }
    }
}
