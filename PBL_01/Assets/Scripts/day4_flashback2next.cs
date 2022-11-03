using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class day4_flashback2next : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("NextScene", 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextScene()
    {
        SceneManager.LoadScene("Day4_flashback2");
    }
}
