using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PassAndFadeOut_Switch_Scene : MonoBehaviour
{
    public Image tool; //부품 이미지
    public Image Black; //검정 화면
    public Button Button;
    float time = 0f;
    float F_time = 1f;
    public string nextScene;

    public void F_In()
    {
        
        StartCoroutine(FadeInFlow()); //다음 버튼을 누르면 부품이미지가 띄워지는 코루틴
    }

    IEnumerator FadeInFlow()
    {
        Button.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !Button.GetComponent<AudioSource>().isPlaying);

        tool.gameObject.SetActive(true);
        time = 0f;
        Color alpha = tool.color;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            tool.color = alpha;
            yield return null;
        }
        Button.gameObject.SetActive(false);

        Invoke("F_Out", 1f); //부품이미지가 페이드 아웃 되는 코루틴 실행


    }

    public void F_Out()
    {
        StartCoroutine(FadeOutFlow1()); //부품이미지가 페이드 아웃 되는 코루틴 실행

    }

    IEnumerator FadeOutFlow1()
    {
        time = 0f;
        Color alpha = tool.color;

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            tool.color = alpha;
            yield return null;
        }
        Invoke("F_Out2", 1f);  //검정 화면을 띄워 페이드 아웃하는 코루틴 실행

    }

    public void F_Out2()
    {
        StartCoroutine(FadeOutFlow2()); //검정 화면을 띄워 페이드 아웃하는 코루틴
    }

    IEnumerator FadeOutFlow2()
    {
        Black.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Black.color;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Black.color = alpha;
            yield return null;
        }
        yield return null;
        SceneManager.LoadScene(nextScene);
    }

    public void Start()
    {
        Black.gameObject.SetActive(false);

    }

}
