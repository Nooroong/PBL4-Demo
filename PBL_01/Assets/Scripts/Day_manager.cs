using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_manager : MonoBehaviour
{
    public GameObject day_image;

    int cnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("day", -1) == 1) //day1 �� ��
        {
            PlayerPrefs.SetInt("sleep", 0); //���ڱ�
        }
        else
        {
            //�ʱ�ȭ �Ǿ �������� �Ǿ��� ��
            if ((bool)GetBool("sleep"))
            {
                day_image.GetComponent<day_Image_ctrl>().Day_Image();

                PlayerPrefs.SetInt("bap", 0); //��Ա�
                PlayerPrefs.SetInt("pill", 0); //��Ա�
                PlayerPrefs.SetInt("planter", 0); //ȭ�� ���ٱ�
                PlayerPrefs.SetInt("random1", 0); //����1
                PlayerPrefs.SetInt("random2", 0); //����2
                PlayerPrefs.SetInt("routine", 0); //�ۿ��� �Ͼ�� ��
                PlayerPrefs.SetInt("sleep", 0); //���ڱ�

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("day", -1) == 1) //day1 �� �� ���� X
        {
            if ((bool)GetBool("sleep"))
            {
                cnt += PlayerPrefs.GetInt("day") + 1;
                PlayerPrefs.SetInt("day", cnt);

                //PlayerPrefs.DeleteKey("sleep");
            }
        }
        else
        {
            //��� ����Ǿ��� �� Ű ���� �ʱ�ȭ
            if ((bool)GetBool("sleep") && (bool)GetBool("bap") && (bool)GetBool("pill") && (bool)GetBool("planter")
                        && (bool)GetBool("random1") && (bool)GetBool("random2") && (bool)GetBool("routine"))
            {
                cnt += PlayerPrefs.GetInt("day") + 1;
                PlayerPrefs.SetInt("day", cnt);

                PlayerPrefs.DeleteKey("bap");
                PlayerPrefs.DeleteKey("pill");
                PlayerPrefs.DeleteKey("planter");
                PlayerPrefs.DeleteKey("random1");
                PlayerPrefs.DeleteKey("random2");
                PlayerPrefs.DeleteKey("routine");
                //PlayerPrefs.DeleteKey("sleep");
                PlayerPrefs.DeleteKey("NoteCp");
            }
        }
    }
    // int ���� 1�̸� true, 2�̸� false
    public static bool? GetBool(string key)
    {
        int tmp = PlayerPrefs.GetInt(key);
        if (tmp == 1)
            return true;
        else if (tmp == 0)
            return false;
        else
            return null;
    }
}
