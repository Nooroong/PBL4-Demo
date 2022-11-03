using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PartsCheck : MonoBehaviour
{
    public Text ch; //체크 텍스트 변수
    public Image plate; //접시 위 부품
    public string nextScene = ""; //다음 씬 이름

    public Image Panel;
    float time = 0f;
    float F_time = 2f;
    bool flag = true;

    private void Update() {
        if(Input.GetMouseButtonUp(0)) {
            int cnt = transform.childCount; //해당 오브젝트의 자식 수

            // 부품의 수는 4개
            if (cnt >= 4) {
                ch.gameObject.SetActive(true); //손에 모든 부품을 올리면 통과.(텍스트 활성화)

                //기억 터치 비활성화
                for (int i = 0; i < transform.childCount; i++)
                    transform.GetChild(i).GetComponent<MemoryMovement>().enabled = false;

                //페이드 아웃 중 터치시 화면이 깜박거리는 현상을 방지
                //화면을 아무리 터치해도 F_Out()이 최초 1회만 동작하도록 한다.
                if (flag) {
                    StartCoroutine(FadeText());
                    Invoke("F_Out", 1f);
                    flag = !flag;
                }
            } else { //부품이 5개 미만인 경우
                ch.gameObject.SetActive(false);
            }
        }
        
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
        NextScene();
    }
    void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }


    public IEnumerator FadeText() {
        ch.gameObject.SetActive(true);
        ch.color = new Color(ch.color.r, ch.color.g, ch.color.b, 0);
        while (ch.color.a < 1.0f) {
            ch.color = new Color(ch.color.r, ch.color.g, ch.color.b, ch.color.a + (Time.deltaTime / 0.6f));

            yield return null;
        }
        StartCoroutine(FadeTextToZero());
    }

    public IEnumerator FadeTextToZero() {
        ch.color = new Color(ch.color.r, ch.color.g, ch.color.b, 1);
        while (ch.color.a > 0.0f) {
            ch.color = new Color(ch.color.r, ch.color.g, ch.color.b, ch.color.a - (Time.deltaTime / 0.6f));
            yield return null;
        }
        ch.gameObject.SetActive(false);
    }

    public void Start()
    {
        Panel.gameObject.SetActive(false);
        ch.gameObject.SetActive(false);
    }
}
