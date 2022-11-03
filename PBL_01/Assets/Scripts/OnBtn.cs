using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnBtn : MonoBehaviour
{

    public Button Onbtn;
    public Image laser;
    int speed = 80;
    float yMove;

    // Start is called before the first frame update
    void Start()
    {
        laser.gameObject.SetActive(false);
        //Button btn = Onbtn.GetComponent<Button>();
    }

    public void ShowLaser()
    {
        StartCoroutine(LaserFlow());
    }

    IEnumerator LaserFlow()
    {
        yMove = 0;
        laser.gameObject.SetActive(true);

        while (laser.gameObject.transform.position.y > 150.0f)
        {
            yMove = -speed * Time.deltaTime;
            laser.transform.Translate(new Vector3(0, yMove, 0));
            yield return null;
        }
        F_Out();
        yield return null;
    }

    float time = 0f;
    float F_time = 0.5f;

    public void F_Out()
    {
        StartCoroutine(FadeOutFlow());
    }

    IEnumerator FadeOutFlow()
    {
        laser.gameObject.SetActive(true);
        time = 0f;
        Color alpha = laser.color;

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            laser.color = alpha;
            yield return null;
        }
        yield return null;
    }


    public void HideLaser()
    {
        laser.gameObject.SetActive(false);
    }
        
    private void Update()
    {
        //ShowLaser();
    }
}

