using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day3_End : MonoBehaviour
{
    public Image player;
    float speed = 1.6f;
    float xMove;

    void Move()
    {
        xMove = 0;
        player.gameObject.SetActive(true);


        xMove = +speed * Time.deltaTime;
        player.transform.Translate(new Vector3(xMove, 0, 0));

    }


    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
