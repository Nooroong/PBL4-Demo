using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpaceshipSprite : MonoBehaviour
{
    Animator m_Animator;
    public GameObject image;
    public Text dialogText;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (dialogText.text == "'")
        {
            m_Animator.GetComponent<Animator>().enabled = true;
        }
        
        if (dialogText.text == "���ΰ��� ��")
        {
            m_Animator.GetComponent<Animator>().enabled = false;
            image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\19_0", typeof(Sprite)) as Sprite;
        }

        if (dialogText.text == "���ΰ��� ���ÿ� ���� ������Ʈ�� �Ǵ�.")
        {
            image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\19_1", typeof(Sprite)) as Sprite;
        }
    }
}
