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
        
        if (dialogText.text == "주인공은 지")
        {
            m_Animator.GetComponent<Animator>().enabled = false;
            image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\19_0", typeof(Sprite)) as Sprite;
        }

        if (dialogText.text == "주인공은 지시에 따라 안전벨트를 맨다.")
        {
            image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\19_1", typeof(Sprite)) as Sprite;
        }
    }
}
