using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Moving : MonoBehaviour
{
    public float speed;
    public Transform[] backgrounds;

    float time = 0f;
    float F_time = 4f;

    float leftPosX = 0f;
    float rightPosX = 0f;
    float xScreenHalfSize;
    float yScreenHalfSize;

    // Start is called before the first frame update
    void Start()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        leftPosX = -(xScreenHalfSize * 2);
        rightPosX = xScreenHalfSize * 2 * backgrounds.Length;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            time += Time.deltaTime / F_time;
            if (time > F_time)
            {
                speed =0;
            }
        }
    }
}
