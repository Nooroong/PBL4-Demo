using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note0_Btn : MonoBehaviour
{
    public GameObject Note0, Note1;
    public Button btn;
    public Text text;
    public Text ps;

    // Start is called before the first frame update
    void Start()
    {
        ps.gameObject.SetActive(false);
        switch (PlayerPrefs.GetInt("day"))
        {
            case 2:

                text.text = "�ȳ�, �ٽ� �� �� ������ �°� ȯ����." + "\n"+
                            "���� ��ħ ���� ����ϰ� ���� �ʰ� ����ؼ� �Ƹ� �ʿ� ������ ���� �� �����ž�." + "\n" +
                            "��� ���� ��ħ���� ������ ������ �����." + "\n" +
                            "ps. ���� ����� ������ ������ ì�ܸԾ�." + "\n" +
                            "������ �� ��Ⱑ ���Դ���. ��Ź ���� �Ź� Ȯ���غ�.";
                break;
            case 3:
                
                if(PlayerPrefs.GetString("note").Contains("����Ͻð� �ǰ��Ͻ��ٵ� ���� �ֹ�����!"))
                {
                    ps.text = "���� ���� �ͼ� ������� �����ٵ� ����� ì������ ���� �̾���.";
                }
                else if(PlayerPrefs.GetString("note").Contains("���� �� �ǿ�� �� �����Կ�!"))
                {
                    ps.text = "�� ���� ���� �� �ϰ� ���´��� �ñ��ϱ���.";
                }
                else
                {
                    ps.text = "���� �� �� ������ ���ڱ���.";
                }
                text.text = "��ħ ���� ������ �� �ʰ� �����ϱ� �� �� ���� ����." + "\n" +
                            "���� �Ϸ絵 ������ �� ����! ���⼭ ������ ���� �������� ���ϰ� ������." + "\n" +
                            "���õ� �� �԰� �� ������. ���� ������ ���� �����ϱ� �����غ�." + "\n" +
                            ps.text;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextNote()
    {
        StartCoroutine(nextNote_co(btn));
    }

    IEnumerator nextNote_co(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        Note0.SetActive(false);
        Note1.SetActive(true);
    }
}
