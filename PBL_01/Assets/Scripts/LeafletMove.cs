using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeafletMove : MonoBehaviour
{
    public Image img;
    int speed = 3;
    float yMove;


    public void ShowPlayer() {
        yMove = 0;
        
        // img.gameObject.transform.position.y < 450.0f
        if (Camera.main.WorldToScreenPoint(img.gameObject.transform.position).y < Camera.main.WorldToScreenPoint(new Vector3(0, 0, 0)).y) { // 카메라 기준
            yMove = +speed * Time.deltaTime;
            img.transform.Translate(new Vector3(0, yMove, 0));

        } else {
            Invoke("NextScene", 2.0f);
        }
    }

    // Update is called once per frame
    void Update() {
        ShowPlayer();
    }


    void NextScene() {
        SceneManager.LoadScene("HospitalReception2");
    }
}
