using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn_text : MonoBehaviour
{
    public Text text;

    float time = 0f;
    float F_time = 5f;

    public void F_In()
    {
        StartCoroutine(FadeInFlow());
    }

    IEnumerator FadeInFlow()
    {
        text.gameObject.SetActive(true);
        time = 0f;
        Color alpha = text.color;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            text.color = alpha;
            yield return null;
        }
        yield return null;
    }

    public void Awake()
    {
        F_In();
    }
}
