using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeaTime : MonoBehaviour
{
    public Image kettle, tea;
    int speed = 320;
    float yMove;
    float kettel_y, tea_y;
    float time_k, time_t;
    void Start()
    {
        kettel_y = kettle.gameObject.transform.position.y;
        tea_y = tea.gameObject.transform.position.y;
    }
    public void B_water()
    {
        StartCoroutine(BoilingWaterFlow());
    }

    IEnumerator BoilingWaterFlow()
    {
        yMove = 0;
        time_k = 0;
        //while (kettle.gameObject.transform.position.y < 1500.0f)
        while(time_k <= 3.0f)
        {
            time_k = time_k + Time.deltaTime;
            yMove = speed * Time.deltaTime;
            kettle.transform.Translate(new Vector3(0, yMove, 0));
            yield return null;
        }
        yield return new WaitForSeconds(3.0f);

        yMove = 0;
       // while (kettle.gameObject.transform.position.y >= 540.0f)
        while (kettle.gameObject.transform.position.y >= kettel_y)
        {
            yMove = -speed * Time.deltaTime;
            kettle.transform.Translate(new Vector3(0, yMove, 0));
            yield return null;
        }
        yield return null;
    }

    public void A_Tea()
    {
        StartCoroutine(AddTea());
    }

    IEnumerator AddTea()
    {
        yMove = 0;
        time_t = 0; 
        while (time_t <= 3.0f)
        {
            time_t = time_t + Time.deltaTime;
            yMove = speed * Time.deltaTime;
            tea.transform.Translate(new Vector3(0, yMove, 0));
            yield return null;
        }
        yield return new WaitForSeconds(2.0f);

        yMove = 0;

        while (tea.gameObject.transform.position.y >= tea_y)
        {
            yMove = -speed * Time.deltaTime;
            tea.transform.Translate(new Vector3(0, yMove, 0));
            yield return null;
        }
        yield return null;
    }

    public void nextScene()
    {
        SceneManager.LoadScene("TeaTime2");
    }
    public void Awake()
    {
        Invoke("A_Tea", 3);
        Invoke("B_water", 10);
        Invoke("nextScene", 30);
    }
}
