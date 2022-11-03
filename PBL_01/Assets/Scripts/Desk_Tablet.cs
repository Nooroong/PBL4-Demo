using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Desk_Tablet : MonoBehaviour
{
    public Button Tablet;
    public Text text;


    GameObject Memo_ctrl;

    // Start is called before the first frame update
    void Start() {
        text.gameObject.SetActive(false);

        //메모 가져오기
        Memo_ctrl = GameObject.Find("Memo_ctrl");
    }


    public void BtnClick() {
        Complete();
        text.gameObject.SetActive(true);
        Tablet.GetComponent<Button>().interactable = false;
        StartCoroutine(FadeTextToZero());
    }

    public IEnumerator FadeTextToZero() {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }

    }

    public void Complete() {
        Memo_ctrl.gameObject.GetComponent<Memo_dontdestroy>().Take_A_Pill();
    }
}
