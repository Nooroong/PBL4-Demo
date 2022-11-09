using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Credit : MonoBehaviour
{
    public void Start()
    {
        Invoke("Next", 12f);
    }

    void Next()
    {
        SceneManager.LoadScene("main");
    }
}
