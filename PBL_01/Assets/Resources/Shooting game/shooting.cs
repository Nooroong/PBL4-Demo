using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class shooting : MonoBehaviour
{
    public GameObject direct;
    public Image mark;
    public Image aim;
    public Button btn;

    bool triggered = false;

    Vector2 shoot;

    // Start is called before the first frame update
    void Start() { 

    }
    void Update()
    {
        triggered = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("충돌");
        triggered = true;

    }
    public void Button_click()
    {
        if (triggered && mark.gameObject.activeSelf == false )
        {
            shoot = aim.transform.position;
            mark.transform.position = shoot;
            mark.gameObject.SetActive(true);

            direct.GetComponent<Shooting_Director>().gaugeUp();
        }
    }
}
