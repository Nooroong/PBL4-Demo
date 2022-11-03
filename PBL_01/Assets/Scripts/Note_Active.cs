using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note_Active : MonoBehaviour
{
    public GameObject note1, note2, note3;
    public Text text;

    void Awake()
    {
        //text.text = PlayerPrefs.GetString("note");
        
    }

    // Start is called before the first frame update
    void Start()
    {


;        if (PlayerPrefs.GetInt("NoteCp") == 1)
        {
            note1.SetActive(false);
            note2.SetActive(false) ;
            note3.SetActive(true);
            
        }
        else
        {
            note1.SetActive(true);
            note2.SetActive(false);
            note3.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
