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
 
            if (dialogText.text == "���Խ��ϴ�. �ϴ� �� ������ ���ô�.")
            {
                m_Animator.GetComponent<Animator>().enabled = false;
                image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\2", typeof(Sprite)) as Sprite;
            }
            if (dialogText.text == "���� ������ ��ô� �������� �Ƹ� �ɸ������� ����")
            {
                image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\1_0", typeof(Sprite)) as Sprite;
                m_Animator.GetComponent<Animator>().enabled = true;
            }
    }
}
