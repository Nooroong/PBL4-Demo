using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backspace : MonoBehaviour
{
    public Text label; //���� �Է� ĭ


    public void Onclicked() {
        //�Էµ� ���ڿ��� ����
        int leng = label.GetComponent<Text>().text.Length;

        //�� ���� �� ���ڸ� �ڸ�
        if (leng > 0)
            label.GetComponent<Text>().text = label.GetComponent<Text>().text.Substring(0, leng - 1);

    }
}
