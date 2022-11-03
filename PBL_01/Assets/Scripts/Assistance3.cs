using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assistance3 : MonoBehaviour
{
    public Camera m_cam; // 카메라

    public Image Background;
    public Image Player;

    Vector3 BG_screenPos; //새로운 BG 포지션
    Vector3 P_screenPos; //새로운 Player 포지션

    float speed = 1.6f; // 1/50배
    float speed1 = 3.0f;
    float yMove;
    float xMove;

    void Move()
    {
        yMove = 0;
        //Background.gameObject.transform.position.y
        if (BG_screenPos.y > 380.0f)
        {
            yMove = -speed * Time.deltaTime;
            Background.transform.Translate(new Vector3(0, yMove, 0));
        }
    }
    public void PlayerMv()
    {
        
        if (P_screenPos.x > 520.0f)
       {
            xMove = 0;

            xMove = -speed1 * Time.deltaTime;
            Player.transform.Translate(new Vector3(xMove, 0, 0));
        }
    }
    void Show()
    {
        Player.gameObject.SetActive(true);
        PlayerMv();
    }
     
    void Update()
    {
        BG_screenPos = m_cam.WorldToScreenPoint(Background.gameObject.transform.position);
        P_screenPos = m_cam.WorldToScreenPoint(Player.gameObject.transform.position);

        Move();
        Invoke("Show", 5f);
    }
    void Start()
    {
        Player.gameObject.SetActive(false);
    }

}
