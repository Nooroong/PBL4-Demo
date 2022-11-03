using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneNumInput : MonoBehaviour {
    public Text label; //���� �Է� ĭ

    private void Start() {
        //�ڽ�(��ư)�� �ڽ�(�ؽ�Ʈ)�� �����ͼ� �̸� ����
        for (int i = 0; i < transform.childCount; i++) {
            var btn = transform.GetChild(i);
            var btnText = transform.GetChild(i).GetChild(0);

            //�� ��ư�� ������ id(int)�� �ο��Ͽ� ����(0~11)
            var identifier = btn.GetComponent<BtnIdentifier>();
            identifier.id = i;

            if (i == 9) btnText.GetComponent<Text>().text = "*";
            else if (i == 10) btnText.GetComponent<Text>().text = "0";
            else if (i == 11) btnText.GetComponent<Text>().text = "#";
            else btnText.GetComponent<Text>().text = (i + 1).ToString();
        }
    }


    public void Onclicked(BtnIdentifier idf) {
        //Ŭ���� ��ư�� id�� ����. �ش� ��ư�� �ڽ�(text)�� ���´�.
        var t = this.transform.GetChild(idf.id).GetChild(0);

        //�Է��� ��ư�� �ؽ�Ʈ ������ �߰�. 8���ڱ��� �Է� ����.
        if(label.GetComponent<Text>().text.Length < 8)
            label.GetComponent<Text>().text += t.GetComponent<Text>().text;
    }
}
