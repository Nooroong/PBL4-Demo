using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut_Festival1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("NextScene", 5f);
    }

    void NextScene() {
        SceneManager.LoadScene("Festival_bench");
    }
}
