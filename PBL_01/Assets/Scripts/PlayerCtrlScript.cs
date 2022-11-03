using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//다른 씬에 갔다가 돌아왔을 때, 주인공의 위치를 고정시키기 위한 스크립트

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
