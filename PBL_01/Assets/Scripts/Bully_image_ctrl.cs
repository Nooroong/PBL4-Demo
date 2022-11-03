using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Bully_image_ctrl : MonoBehaviour
{
    public DialogManager dm;
    public GameObject panel, BG;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.SetInt("Bully", 1); //BGM을 위해 Bully true로 설정
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dm.gameObject.GetComponent<DialogManager>().Cnt() == 1)
        {
            BG.GetComponent<Image>().sprite = Resources.Load("Day4\\4_5", typeof(Sprite)) as Sprite;

        }
        if (dm.gameObject.GetComponent<DialogManager>().Cnt() == 2)
        {
            BG.GetComponent<Image>().sprite = Resources.Load("Day4\\4_4", typeof(Sprite)) as Sprite;

        }
    }
}
