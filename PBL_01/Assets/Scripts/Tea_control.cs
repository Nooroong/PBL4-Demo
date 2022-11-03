using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tea_control : MonoBehaviour
{
    public Image Teabag;
    Animator m_Animator;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.GetComponent<Animator>().enabled = false;

        if (choosetea.tea == "chamomile")
        {
            Teabag.GetComponent<Image>().sprite = Resources.Load("TeaTime\\chamomile", typeof(Sprite)) as Sprite;
            m_Animator.SetTrigger("chamomile");
            m_Animator.GetComponent<Animator>().enabled = true;
            choosetea.tea = "chamomile";
        }
        else if (choosetea.tea == "lavender")
        {
            Teabag.GetComponent<Image>().sprite = Resources.Load("TeaTime\\lavender", typeof(Sprite)) as Sprite;
            m_Animator.SetTrigger("lavender");
            m_Animator.GetComponent<Animator>().enabled = true;
            choosetea.tea = "lavender";
        }
        else if (choosetea.tea == "jasmine")
        {
            Teabag.GetComponent<Image>().sprite = Resources.Load("TeaTime\\jasmine", typeof(Sprite)) as Sprite;
            m_Animator.SetTrigger("jasmine");
            m_Animator.GetComponent<Animator>().enabled = true;
            choosetea.tea = "jasmine";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
