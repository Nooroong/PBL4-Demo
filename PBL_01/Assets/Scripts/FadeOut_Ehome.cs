using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut_Ehome : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Image Panel;
    public Image Home;
    public Button Btn;

    float time = 0f;
    float F_time = 2f;

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
        ShowH();
    }

    void ShowH()
    {
        Home.gameObject.SetActive(true);
        Invoke("ShowBtn", 0.5f);
    }

    void ShowBtn()
    {
        Btn.gameObject.SetActive(true);
    }

    public void Start()
    {
        Invoke("F_Out", 4f);
        //Home.gameObject.SetActive(false);
    }
}
