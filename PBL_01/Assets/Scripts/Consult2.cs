using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Consult2 : MonoBehaviour
{
    public Camera m_cam;

    Vector3 D_screenPos;

    public Image door;

    float speed = 3.2f;
    float xMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowDoor()
    {
        xMove = 0;

        // D_screenPos.x > 570.0f
        if (door.GetComponent<RectTransform>().anchoredPosition.x > -500f)
        {
            xMove = -speed * Time.deltaTime;
            door.transform.Translate(new Vector3(xMove, 0, 0));

        }
        Invoke("NextScene", 4f);

    }
    
    public void NextScene()
    {
        if (D_screenPos.x < 570.0f)
        {
            SceneManager.LoadScene("Consult3");
        }
    }

  

    // Update is called once per frame
    void Update()
    {
        D_screenPos = m_cam.WorldToScreenPoint(door.gameObject.transform.position);
        ShowDoor();
    }
}
