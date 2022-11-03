using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHomeSprite : MonoBehaviour
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

        if (dialogText.text == "침")
        {
            m_Animator.GetComponent<Animator>().enabled = true;
            image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\2", typeof(Sprite)) as Sprite;
        }
        if (dialogText.text == "")
        {
            m_Animator.GetComponent<Animator>().enabled = false;
            image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\9", typeof(Sprite)) as Sprite;

        }
    }
}
