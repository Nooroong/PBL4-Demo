using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Day4_start_fade : MonoBehaviour
{
    public Image Panel1, Panel2, black;
    float time = 0f;
    float F_time = 2f;

    public void FadeOut(Image image, float w_time)
    {
        time = 0f;
        StartCoroutine(FadeOutFlow(image, w_time));
    }
    IEnumerator FadeOutFlow(Image image, float w_time)
    {

        image.gameObject.SetActive(true);
        Color alpha = image.color;

        yield return new WaitForSeconds(w_time);

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            image.color = alpha;
            yield return null;
        }
        time = 0f;
        yield return null;
    }

    public void FadeOut_b(Image image, float w_time)
    {
        time = 0f;
        StartCoroutine(FadeOutFlow_b(image, w_time));
    }
    IEnumerator FadeOutFlow_b(Image image, float w_time)
    {

        image.gameObject.SetActive(true);
        Color alpha = image.color;

        yield return new WaitForSeconds(w_time);

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            image.color = alpha;
            yield return null;
        }
        time = 0f;
        SceneManager.LoadScene("Day4_Bully");
        yield return null;
    }
    public void Start()
    {
        FadeOut(Panel1, 4.0f);
        FadeOut(Panel2, 8.0f);
        FadeOut_b(black, 12.0f);
    }
}

