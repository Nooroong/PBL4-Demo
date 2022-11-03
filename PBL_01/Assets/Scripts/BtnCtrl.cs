using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnCtrl : MonoBehaviour
{
    public Toggle toggle1_1;
    public Toggle toggle1_2;
    public Toggle toggle2_1;
    public Toggle toggle2_2;
    public Toggle toggle3_1;
    public Toggle toggle3_2;
    public Toggle toggle4_1;
    public Toggle toggle4_2;
    public Toggle toggle5_1;
    public Toggle toggle5_2;
    public Toggle toggle6_1;
    public Toggle toggle6_2;
    public Toggle toggle7_1;
    public Toggle toggle7_2;
    public Toggle toggle8_1;
    public Toggle toggle8_2;
    public Toggle toggle9_1;
    public Toggle toggle9_2;
    public Toggle toggle10_1;
    public Toggle toggle10_2;

    private Button btn;

    public void Start() {
        //�Ʒ� ����ǥ �ȿ� �ش�Ǵ� ��ư ������Ʈ�� �̸��� ���´�.
        btn = GameObject.Find("Complete").GetComponent<Button>();
        btn.interactable = false; //��ư ��ȣ�ۿ� ��Ȱ��ȭ
    }

    public void BtnState() {
        //!�Ʒ� ���� ����!
        if ((toggle1_1.isOn == true || toggle1_2.isOn == true) && 
            (toggle2_1.isOn == true || toggle2_2.isOn == true) &&
            (toggle3_1.isOn == true || toggle3_2.isOn == true) &&
            (toggle4_1.isOn == true || toggle4_2.isOn == true) &&
            (toggle5_1.isOn == true || toggle5_2.isOn == true) &&
            (toggle6_1.isOn == true || toggle6_2.isOn == true) &&
            (toggle7_1.isOn == true || toggle7_2.isOn == true) &&
            (toggle8_1.isOn == true || toggle8_2.isOn == true) &&
            (toggle9_1.isOn == true || toggle9_2.isOn == true) &&
            (toggle10_1.isOn == true || toggle10_2.isOn == true)) { //��� �׸��� üũ�� ���
            btn.interactable = true; //��ư ��ȣ�ۿ� Ȱ��ȭ
        } else { //�׸��� ��� üũ���� ���� ���
            btn.interactable = false; //��ư ��ȣ�ۿ� ��Ȱ��ȭ
        }
    }
    public void Update()
    {
        BtnState();
    }
    
    public Image black;

    float time = 0f;
    float F_time = 3f;

    public void Onclick()
    {
        FadeOut();
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutFlow());
    }

    IEnumerator FadeOutFlow()
    {
        yield return StartCoroutine(UntilPlayback(this.GetComponent<Button>()));

        black.gameObject.SetActive(true);
        time = 0f;
        Color alpha = black.color;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            black.color = alpha;
            yield return null;
        }
        SceneManager.LoadScene("HospitalMachine");
        yield return null;
    }

    IEnumerator UntilPlayback(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
    }
}
