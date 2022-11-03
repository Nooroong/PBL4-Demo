using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StreetWalkingLoad : MonoBehaviour
{
    public Image day_panel;
    public Image Panel;
    float time = 0f;
    float F_time = 1.5f;

    private void Awake()
    {
        FadeIn(day_panel);
        Invoke("F_In_Black", 2f);
    }
    public void F_In_Black()
    {
        FadeIn(Panel);
    }
    private void Start()
    {
        Invoke("F_Out", 5f);
    }
    public void FadeIn(Image panel)
    {
        StartCoroutine(FadeInFlow(panel));
    }
    IEnumerator FadeInFlow(Image panel)
    {
        time = 0f;
        Color alpha = panel.color;

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            panel.color = alpha;
            yield return null;
        }
        panel.gameObject.SetActive(false);
        yield return null;
    }
    public void F_Out()
    {

        StartCoroutine(FadeOutFlow());
    }

    IEnumerator FadeOutFlow()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
        SceneManager.LoadScene("StreetWalking");
    }
}
