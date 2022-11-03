using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneNumInput : MonoBehaviour {
    public Text label; //정답 입력 칸

    private void Start() {
        //자식(버튼)의 자식(텍스트)를 가져와서 이름 변경
        for (int i = 0; i < transform.childCount; i++) {
            var btn = transform.GetChild(i);
            var btnText = transform.GetChild(i).GetChild(0);

            //각 버튼에 고유의 id(int)를 부여하여 구분(0~11)
            var identifier = btn.GetComponent<BtnIdentifier>();
            identifier.id = i;

            if (i == 9) btnText.GetComponent<Text>().text = "*";
            else if (i == 10) btnText.GetComponent<Text>().text = "0";
            else if (i == 11) btnText.GetComponent<Text>().text = "#";
            else btnText.GetComponent<Text>().text = (i + 1).ToString();
        }
    }


    public void Onclicked(BtnIdentifier idf) {
        //클릭된 버튼을 id로 구분. 해당 버튼의 자식(text)을 얻어온다.
        var t = this.transform.GetChild(idf.id).GetChild(0);

        //입력한 버튼을 텍스트 끝에다 추가. 8글자까지 입력 가능.
        if(label.GetComponent<Text>().text.Length < 8)
            label.GetComponent<Text>().text += t.GetComponent<Text>().text;
    }
}
