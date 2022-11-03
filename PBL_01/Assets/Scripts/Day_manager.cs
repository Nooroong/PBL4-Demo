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
        if(PlayerPrefs.GetInt("day", -1) == 1) //day1 일 때
        {
            PlayerPrefs.SetInt("sleep", 0); //잠자기
        }
        else
        {
            //초기화 되어서 다음날이 되었을 때
            if ((bool)GetBool("sleep"))
            {
                day_image.GetComponent<day_Image_ctrl>().Day_Image();

                PlayerPrefs.SetInt("bap", 0); //밥먹기
                PlayerPrefs.SetInt("pill", 0); //약먹기
                PlayerPrefs.SetInt("planter", 0); //화분 가꾸기
                PlayerPrefs.SetInt("random1", 0); //랜덤1
                PlayerPrefs.SetInt("random2", 0); //랜덤2
                PlayerPrefs.SetInt("routine", 0); //밖에서 일어나는 일
                PlayerPrefs.SetInt("sleep", 0); //잠자기

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("day", -1) == 1) //day1 일 때 조건 X
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
            //모두 진행되었을 때 키 삭제 초기화
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
    // int 값이 1이면 true, 2이면 false
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
