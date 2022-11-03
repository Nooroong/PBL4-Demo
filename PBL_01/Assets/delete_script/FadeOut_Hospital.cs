using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut_Hospital : MonoBehaviour
{
    public Image Panel;
    Animator anim;

    float time = 0f;
    float F_time = 2f;

    public void F_Out()
    {
        anim.GetComponent<Animator>().enabled = false;

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
        SceneManager.LoadScene("Prologue_Toilet");
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }
}
