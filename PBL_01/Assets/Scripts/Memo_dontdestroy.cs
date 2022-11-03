using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Memo_dontdestroy : MonoBehaviour
{
    public GameObject Memo_ctrl;
    public TextMeshProUGUI text1, text2, text3, text4, text5;

    void Awake()
    {
        var obj = FindObjectsOfType<Memo_dontdestroy>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(Memo_ctrl);
        }
        else
        {
            Destroy(Memo_ctrl);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetInt("task_index", -1))
        {
            case 0:
                text4.text = "산책하기";
                text5.text = "차 마시기";
                break;
            case 1:
                text4.text = "명상하기";
                text5.text = "차 마시기";
                break;
            case 2:
                text4.text = "명상하기";
                text5.text = "산책하기";
                break;
        }

        //할 일이 True 라면 취소선
        if ((bool)Day_manager.GetBool("bap"))
        {
            text1.text = "<s>" + text1.text + "</s>";
        }
        if ((bool)Day_manager.GetBool("pill"))
        {
            text2.text = "<s>" + text2.text + "</s>";
        }
        if ((bool)Day_manager.GetBool("planter"))
        {
            text3.text = "<s>" + text3.text + "</s>";
        }
        if ((bool)Day_manager.GetBool("random1"))
        {
            text4.text = "<s>" + text4.text + "</s>";
        }
        if ((bool)Day_manager.GetBool("random2"))
        {
            text5.text = "<s>" + text5.text + "</s>";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerPrefs.HasKey("bap") && !PlayerPrefs.HasKey("pill") && !PlayerPrefs.HasKey("planter")
            && !PlayerPrefs.HasKey("random1") && !PlayerPrefs.HasKey("random2"))
        {
            Destroy(Memo_ctrl);
        }
    }
    public void Eating()
    {
        text1.text = "<s>" + text1.text + "</s>";
        PlayerPrefs.SetInt("bap", 1);
    }
    public void Take_A_Pill()
    {
        text2.text = "<s>" + text2.text + "</s>";
        PlayerPrefs.SetInt("pill", 1);
    }
    public void Planter()
    {
        text3.text = "<s>" + text3.text + "</s>";
        PlayerPrefs.SetInt("planter", 1);
    }
    public void Walking()
    {
        if (text4.text.Contains("산책"))
        {
            text4.text = "<s>" + text4.text + "</s>";
            PlayerPrefs.SetInt("random1", 1);
        }

        else
        {
            text5.text = "<s>" + text5.text + "</s>";
            PlayerPrefs.SetInt("random2", 1);
        }
    }
    public void Meditation()
    {
        if (text4.text.Contains("명상"))
        {
            text4.text = "<s>" + text4.text + "</s>";
            PlayerPrefs.SetInt("random1", 1);
        }

        else
        {
            text5.text = "<s>" + text5.text + "</s>";
            PlayerPrefs.SetInt("random2", 1);
        }
    }
    public void Tea()
    {
        if (text4.text.Contains("차"))
        {
            text4.text = "<s>" + text4.text + "</s>";
            PlayerPrefs.SetInt("random1", 1);
        }

        else
        {
            text5.text = "<s>" + text5.text + "</s>";
            PlayerPrefs.SetInt("random2", 1);
        }
    }
}
