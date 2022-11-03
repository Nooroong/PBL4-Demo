using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_move : MonoBehaviour
{
    public Camera m_cam; // 카메라
    //Vector3 t1_screenPos, t2_screenPos, t3_screenPos, t4_screenPos;

    public GameObject t1, t2, t3, t4;

    public float speed = 0.1f;
    float yMove;
    int r_num1, r_num2, r_num3, r_num4;

    void Awake()
    {
        r_num1 = Random.Range(0, 10);
        r_num2 = Random.Range(0, 10);
        r_num3 = Random.Range(0, 10);
        r_num4 = Random.Range(0, 10);
    }
    // Start is called before the first frame update
    void Start()
    {
        UpandDown(r_num1, t1);
        UpandDown(r_num2, t2);
        UpandDown(r_num3, t3);
        UpandDown(r_num4, t4);
    }
    void Update()
    {

    }
    public void UpandDown(int random, GameObject target)
    {
        if ( random > 4)
        {
            Up(target);
        }
        else
        {
            Down(target);
        }
    }
    public void Up(GameObject target)
    {
        StartCoroutine(UpFlow(target));
    }
    public void Down(GameObject target)
    {
        StartCoroutine(DownFlow(target));
    }
    public void Stop()
    {
        speed = 0;
    }
    IEnumerator UpFlow(GameObject target)
    {
        
        // m_cam.WorldToScreenPoint(target.gameObject.transform.position).y < 755.0f
        while (target.GetComponent<RectTransform>().anchoredPosition.y < 1212.0f)
        {
            yMove = 0;
            yMove = speed;
            target.transform.Translate(new Vector3(0, yMove, 0));
            yield return null;
        }
        StartCoroutine(DownFlow(target));
        yield return null;
    }
    IEnumerator DownFlow(GameObject target)
    {

        // m_cam.WorldToScreenPoint(target.gameObject.transform.position).y > 255.0f
        while (target.GetComponent<RectTransform>().anchoredPosition.y > 650.0f)
        {
            yMove = 0;
            yMove = -speed;
            target.transform.Translate(new Vector3(0, yMove, 0));
            yield return null;
        }
        StartCoroutine(UpFlow(target));
        yield return null;
    }
}
