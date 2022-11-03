using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backspace : MonoBehaviour
{
    public Text label; //정답 입력 칸


    public void Onclicked() {
        //입력된 문자열의 길이
        int leng = label.GetComponent<Text>().text.Length;

        //맨 끝에 한 글자만 자름
        if (leng > 0)
            label.GetComponent<Text>().text = label.GetComponent<Text>().text.Substring(0, leng - 1);

    }
}
