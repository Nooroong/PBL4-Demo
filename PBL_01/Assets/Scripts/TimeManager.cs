/*
 https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=2983934&logNo=220987664525
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {
    public Text label; //���� �Է� ĭ
    public Text alertText; //�˸�â
    public Text alertText2;
    public Image Panel;
    float time = 0f;
    float F_time =7f;

    private void Start() {
        alertText.gameObject.SetActive(false);
        alertText2.gameObject.SetActive(false);
        Panel.gameObject.SetActive(false);
    }

    /*
    // Update is called once per frame
    void Update() {
        //�ð��� ���Ұų� ������ �Է����� ���� ���, �����Ӹ��� �ð��� ����
        if (time > 0f && (label.GetComponent<Text>().text != "119"))

        //�ð� ����
        time -= Time.deltaTime;
        timeText.text = time.ToString();
        timeText.text = string.Format("{0:N2}", time);
        
        //�ð��� ������ ������ ��츦 ����
        if (time <= 0) timeText.text = "0.00";
    }
    */

    //��ȭ ��ư Ŭ�� ��
    public void OnClicked() {
        if (label.GetComponent<Text>().text != "119") { //�Էµ� ��ȭ��ȣ�� 119�� �ƴ� ��
            //�߸��� ��ȣ��� �˸�â ����
            StartCoroutine(FadeText());
        }
        else { //�ùٸ� ��ȭ��ȣ�� �Է�
            //���� ��ư��
            GameObject BtnsGrid = GameObject.Find("NumGrid"); //����� �ڽĵ��� ���� ��Ȱ��ȭ
            //�ùٸ� ������� �˸�â ����
            StartCoroutine(FadeText2());
            for (int i = 0; i < BtnsGrid.transform.childCount; i++) {
                var btn = BtnsGrid.transform.GetChild(i);
                btn.GetComponent<Button>().interactable = false;
                Invoke("F_Out", 1f);
            }

            //����� ��ư�� ��Ȱ��ȭ
            GameObject.Find("backspace").GetComponent<Button>().interactable = false;
        }
    }


    public IEnumerator FadeText() {
        yield return StartCoroutine(UntilPlayback(this.GetComponent<Button>()));
        
        alertText.gameObject.SetActive(true);
        alertText.color = new Color(alertText.color.r, alertText.color.g, alertText.color.b, 0);
        while (alertText.color.a < 1.0f) {
            alertText.color = new Color(alertText.color.r, alertText.color.g, alertText.color.b, alertText.color.a + (Time.deltaTime / 0.6f));

            yield return null;
        }
        StartCoroutine(FadeTextToZero());
    }

    public IEnumerator FadeTextToZero() {
        alertText.color = new Color(alertText.color.r, alertText.color.g, alertText.color.b, 1);
        while (alertText.color.a > 0.0f) {
            alertText.color = new Color(alertText.color.r, alertText.color.g, alertText.color.b, alertText.color.a - (Time.deltaTime / 0.6f));
            yield return null;
        }
        alertText.gameObject.SetActive(false);
    }

    public IEnumerator FadeText2()
    {
        yield return StartCoroutine(UntilPlayback(this.GetComponent<Button>()));

        alertText2.gameObject.SetActive(true);
        alertText2.color = new Color(alertText2.color.r, alertText2.color.g, alertText2.color.b, 0);
        while (alertText2.color.a < 1.0f)
        {
            alertText2.color = new Color(alertText2.color.r, alertText2.color.g, alertText2.color.b, alertText2.color.a + (Time.deltaTime / 0.6f));

            yield return null;
        }
        StartCoroutine(FadeTextToZero2());
    }

    public IEnumerator FadeTextToZero2()
    {
        alertText2.color = new Color(alertText2.color.r, alertText2.color.g, alertText2.color.b, 1);
        while (alertText2.color.a > 0.0f)
        {
            alertText2.color = new Color(alertText2.color.r, alertText2.color.g, alertText2.color.b, alertText2.color.a - (Time.deltaTime / 0.6f));
            yield return null;
        }
        alertText2.gameObject.SetActive(false);
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
        SceneManager.LoadScene("Ambulance");

    }

    IEnumerator UntilPlayback(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
    }

}
