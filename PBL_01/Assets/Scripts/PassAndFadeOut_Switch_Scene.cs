using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PassAndFadeOut_Switch_Scene : MonoBehaviour
{
    public Image tool; //��ǰ �̹���
    public Image Black; //���� ȭ��
    public Button Button;
    float time = 0f;
    float F_time = 1f;
    public string nextScene;

    public void F_In()
    {
        
        StartCoroutine(FadeInFlow()); //���� ��ư�� ������ ��ǰ�̹����� ������� �ڷ�ƾ
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

        Invoke("F_Out", 1f); //��ǰ�̹����� ���̵� �ƿ� �Ǵ� �ڷ�ƾ ����


    }

    public void F_Out()
    {
        StartCoroutine(FadeOutFlow1()); //��ǰ�̹����� ���̵� �ƿ� �Ǵ� �ڷ�ƾ ����

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
        Invoke("F_Out2", 1f);  //���� ȭ���� ��� ���̵� �ƿ��ϴ� �ڷ�ƾ ����

    }

    public void F_Out2()
    {
        StartCoroutine(FadeOutFlow2()); //���� ȭ���� ��� ���̵� �ƿ��ϴ� �ڷ�ƾ
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
