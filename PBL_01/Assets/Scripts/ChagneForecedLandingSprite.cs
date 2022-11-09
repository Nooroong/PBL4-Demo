using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChagneForecedLandingSprite : MonoBehaviour
{
    Animator m_Animator;
    public GameObject image;
    public Text dialogText;
    public Image spaceship;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (dialogText.text == "주인공은 기절을")
        {
            m_Animator.GetComponent<Animator>().enabled = true;
            spaceship.gameObject.SetActive(false);
        }

        if (dialogText.text == "정신을")
        {
            m_Animator.GetComponent<Animator>().enabled = false;
            image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\23_0", typeof(Sprite)) as Sprite;
        }

        if (dialogText.text == "정신을 차린 주인공은 우주선을")
        {
            image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\23_1", typeof(Sprite)) as Sprite;
        }

        if (dialogText.text == "정신을 차린 주인공은 우주선을 나가려고 하는데.")
        {
            image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\23_2", typeof(Sprite)) as Sprite;
        }
    }
}
