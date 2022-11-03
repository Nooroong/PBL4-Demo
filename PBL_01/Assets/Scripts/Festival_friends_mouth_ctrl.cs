using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Festival_friends_mouth_ctrl : MonoBehaviour
{
    public DialogManager dm;
    public GameObject panel;
    public GameObject friend1, friend2, friend3, BG;

    Animator f1_Animator, f2_Animator, f3_Animator, BG_Animator;

    // Start is called before the first frame update
    void Start()
    {
        f1_Animator = friend1.GetComponent<Animator>();
        f1_Animator.GetComponent<Animator>().enabled = true;

        f2_Animator = friend2.GetComponent<Animator>();
        f2_Animator.GetComponent<Animator>().enabled = false;

        f3_Animator = friend3.GetComponent<Animator>();
        f3_Animator.GetComponent<Animator>().enabled = false;

        BG_Animator = BG.GetComponent<Animator>();
        BG_Animator.GetComponent<Animator>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (dm.gameObject.GetComponent<DialogManager>().Cnt() == 1)
        {
            f2_Animator.GetComponent<Animator>().enabled = true;
            f1_Animator.GetComponent<Animator>().enabled = false;
            BG_Animator.GetComponent<Animator>().enabled = false;

            friend1.GetComponent<Image>().sprite = Resources.Load("Day3\\Friends mouth\\friend1_m_close", typeof(Sprite)) as Sprite;
            BG.GetComponent<Image>().sprite = Resources.Load("Day3\\friends5", typeof(Sprite)) as Sprite;
        }
        else if (dm.gameObject.GetComponent<DialogManager>().Cnt() == 2)
        {
            f1_Animator.GetComponent<Animator>().enabled = true;
            f2_Animator.GetComponent<Animator>().enabled = false;

            friend2.GetComponent<Image>().sprite = Resources.Load("Day3\\Friends mouth\\friend2_m_close", typeof(Sprite)) as Sprite;
        }
        else if (dm.gameObject.GetComponent<DialogManager>().Cnt() == 3)
        {
            f1_Animator.GetComponent<Animator>().enabled = false;
            f3_Animator.GetComponent<Animator>().enabled = true;

            friend1.GetComponent<Image>().sprite = Resources.Load("Day3\\Friends mouth\\friend1_m_close", typeof(Sprite)) as Sprite;
        }
        else if (dm.gameObject.GetComponent<DialogManager>().Cnt() == 4)
        {
            f3_Animator.GetComponent<Animator>().enabled = false;

            friend3.GetComponent<Image>().sprite = Resources.Load("Day3\\Friends mouth\\friend3_m_close", typeof(Sprite)) as Sprite;
        }
    }

    
}
