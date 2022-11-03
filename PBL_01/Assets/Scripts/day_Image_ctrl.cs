using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class day_Image_ctrl : MonoBehaviour
{
    public Image day_panel;
    public Image Black;
    public GameObject mechanic;
    float time = 0f;
    float F_time = 1.5f;

    void Awake()
    {
        /*
        if(PlayerPrefs.GetInt("day") == 2)
            day_panel.GetComponent<Image>().sprite = Resources.Load("Day_Image\\day2", typeof(Sprite)) as Sprite;
        else if (PlayerPrefs.GetInt("day") == 3)
            day_panel.GetComponent<Image>().sprite = Resources.Load("Day_Image\\day3", typeof(Sprite)) as Sprite;
        */
        switch (PlayerPrefs.GetInt("day", -1))
        {
            case 2:
                day_panel.GetComponent<Image>().sprite = Resources.Load("Day_Image\\day2", typeof(Sprite)) as Sprite;
                break;
            case 3:
                day_panel.GetComponent<Image>().sprite = Resources.Load("Day_Image\\day3", typeof(Sprite)) as Sprite;
                break;
            case 4:
                day_panel.GetComponent<Image>().sprite = Resources.Load("Day_Image\\day4", typeof(Sprite)) as Sprite;
                break;
            case 5:
                day_panel.GetComponent<Image>().sprite = Resources.Load("Day_Image\\day5", typeof(Sprite)) as Sprite;
                break;
            case 6:
                day_panel.GetComponent<Image>().sprite = Resources.Load("Day_Image\\day6", typeof(Sprite)) as Sprite;
                mechanic.gameObject.SetActive(true);
                break;
        }
    }
    void Update()
    {

    }
    public void Day_Image()
    {
        F_In_day();
    }

    public void F_In_Black()
    {
        StartCoroutine(B_FadeInFlow());
    }
    public void F_In_day()
    {
        StartCoroutine(P_FadeInFlow());
    }

    IEnumerator P_FadeInFlow()
    {
        day_panel.gameObject.SetActive(true);
        Black.gameObject.SetActive(true);
        time = 0f;
        Color alpha = day_panel.color;

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            day_panel.color = alpha;
            yield return null;
        }
        day_panel.gameObject.SetActive(false);
        F_In_Black();
        yield return null;
    }
    IEnumerator B_FadeInFlow()
    {
        time = 0f;
        Color alpha = Black.color;

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Black.color = alpha;
            yield return null;
        }
        Black.gameObject.SetActive(false);
        yield return null;
    }
}
