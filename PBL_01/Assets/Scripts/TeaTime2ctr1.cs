using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeaTime2ctr1 : MonoBehaviour
{
    public Image BG;
    Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.GetComponent<Animator>().enabled = false;

        if (choosetea.tea == "chamomile")
        {
            BG.GetComponent<Image>().sprite = Resources.Load("TeaTime\\pour chamomile bg", typeof(Sprite)) as Sprite;
            m_Animator.SetTrigger("chamomile");
            m_Animator.GetComponent<Animator>().enabled = true;
            choosetea.tea = null;
        }
        else if (choosetea.tea == "lavender")
        {
            BG.GetComponent<Image>().sprite = Resources.Load("TeaTime\\pour lavender bg", typeof(Sprite)) as Sprite;
            m_Animator.SetTrigger("lavender");
            m_Animator.GetComponent<Animator>().enabled = true;
            choosetea.tea = null;
        }
        else if (choosetea.tea == "jasmine")
        {
            BG.GetComponent<Image>().sprite = Resources.Load("TeaTime\\pour jasmine bg", typeof(Sprite)) as Sprite;
            m_Animator.SetTrigger("jasmine");
            m_Animator.GetComponent<Animator>().enabled = true;
            choosetea.tea = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
