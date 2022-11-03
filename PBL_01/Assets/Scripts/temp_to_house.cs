using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class temp_to_house : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SceneChangeToHouse", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChangeToHouse()
    {
        SceneManager.LoadScene("House");
        PlayerPrefs.SetInt("Out", 0);
        PlayerPrefs.SetInt("routine", 1);
    }
}
