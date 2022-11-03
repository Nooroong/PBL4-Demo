using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut_Hospitaldoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("NextScene", 5.0f);
    }

    void NextScene() {
        SceneManager.LoadScene("HospitalReception");
    }
}
