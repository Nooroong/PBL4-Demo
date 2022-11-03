using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHospitalSprite : MonoBehaviour
{
    Animator m_Animator;
    public GameObject image;
    public Text dialogText;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
 
            if (dialogText.text == "나왔습니다. 일단 뇌 사진을 봅시다.")
            {
                m_Animator.GetComponent<Animator>().enabled = false;
                image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\2", typeof(Sprite)) as Sprite;
            }
            if (dialogText.text == "지금 느끼고 계시는 문제들은 아마 심리적으로 느끼")
            {
                image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\1_0", typeof(Sprite)) as Sprite;
                m_Animator.GetComponent<Animator>().enabled = true;
            }
    }
}
