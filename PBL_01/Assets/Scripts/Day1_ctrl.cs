using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1_ctrl : MonoBehaviour
{
    void Awake()
    {
        PlayerPrefs.SetInt("day", 1);
        PlayerPrefs.SetInt("out", 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("day", 1);
        //PlayerPrefs.SetInt("out", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
