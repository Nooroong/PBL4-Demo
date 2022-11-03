using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn_H : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float F_time = 2f;

    public void FadeIn()
    {
        StartCoroutine(FadeInFlow());
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutFlow());
    }
    IEnumerator FadeInFlow()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;
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
    }
    public void Start()
    {
        FadeIn();
    }
}

