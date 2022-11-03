using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Out_ctrl: MonoBehaviour
{
    void Awake()
    {
        PlayerPrefs.SetInt("out", 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("out", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
