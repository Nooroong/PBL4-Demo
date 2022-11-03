using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image Panel;
    public GameObject Btn_Grid;

    float time = 0f;
    float F_time = 2f;

    public void F_In()
    {
        StartCoroutine(FadeInFlow());
    }

    IEnumerator FadeInFlow()
    {
        Panel.gameObject.SetActive(true);
        for (int i = 0; i < Btn_Grid.transform.childCount; i++) {
            Btn_Grid.transform.GetChild(i).gameObject.SetActive(true);
            Btn_Grid.transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
        }
        time = 0f;
        Color pnl_alpha = Panel.color;
        Color btn_alpha = Btn_Grid.transform.GetChild(0).GetComponent<Image>().color;
        Color btn_txt_alpha = Btn_Grid.transform.GetChild(0).GetChild(0).GetComponent<Text>().color;

        yield return new WaitForSeconds(2f);
        while (pnl_alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            pnl_alpha.a = Mathf.Lerp(0, 1, time);
            btn_alpha.a = Mathf.Lerp(0, 1, time);
            btn_txt_alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = pnl_alpha;
            for (int i = 0; i < Btn_Grid.transform.childCount; i++) {
                Btn_Grid.transform.GetChild(i).GetComponent<Image>().color = btn_alpha;
                Btn_Grid.transform.GetChild(i).GetChild(0).GetComponent<Text>().color = btn_txt_alpha;
            }
            yield return null;
        }
        yield return null;
    }

    public void Awake()
    {
        Panel.gameObject.SetActive(false);
        for (int i = 0; i < Btn_Grid.transform.childCount; i++) {
            Btn_Grid.transform.GetChild(i).gameObject.SetActive(false); //버튼 이미지
            Btn_Grid.transform.GetChild(i).GetChild(0).gameObject.SetActive(false); //버튼 텍스트
        }

        //초회 플레이라면 이어하기 버튼을 비활성화
        if(!PlayerPrefs.HasKey("Last_scene")) {
            Btn_Grid.transform.Find("Continue").GetComponent<Button>().interactable = false;
        }

        F_In();
    }
}
