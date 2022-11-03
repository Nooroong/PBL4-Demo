using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCafeSprite : MonoBehaviour
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

        if (dialogText.text == "진짜? 무슨 일 있었어?")
        {
            m_Animator.GetComponent<Animator>().enabled = true;
        }
    }
}
