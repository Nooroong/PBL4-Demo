using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Siren : MonoBehaviour
{
    public Image Panel;
    public AudioSource siren_sound;

    float time1 = 0f;
    float time2 = 0f;
    float F_time = 3f;

    public void F_In()
    {
        StartCoroutine(FadeInFlow());
    }

    IEnumerator FadeInFlow()
    {
        Panel.gameObject.SetActive(true);
        time1 = 0f;
        Color alpha = Panel.color;

        while (alpha.a < 1f)
        {
            time1 += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time1);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
    }

    IEnumerator FadeSound() {
        time2 = 0f;
        float vol = 1.0f;

        while (vol <= 1f)
        {
            time2 += Time.deltaTime / 9.0f;
            vol = Mathf.Lerp(1, 0, time2);
            siren_sound.volume = vol;
            yield return null;
        }
        yield return null;
    }

    void Start()
    {
        StartCoroutine(FadeSound());
        Invoke("F_In", 3f);
    }
}
