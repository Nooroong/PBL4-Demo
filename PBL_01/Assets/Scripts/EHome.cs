using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EHome : MonoBehaviour
{
    public Camera m_cam;
    Vector3 D_screenPos;

    public Image door;
    float speed = 2f;
    float xMove;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    public void MoveDoor()
    {
        xMove = 0;

        if (D_screenPos.x > 0.0f)
        {
            xMove = -speed * Time.deltaTime;
            door.transform.Translate(new Vector3(xMove, 0, 0));

        }
    }

    // Update is called once per frame
    void Update()
    {
        D_screenPos = m_cam.WorldToScreenPoint(door.gameObject.transform.position);
        MoveDoor();
    }
}
