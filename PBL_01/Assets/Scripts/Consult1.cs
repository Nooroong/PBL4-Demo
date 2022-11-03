using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Consult1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("NextScene", 3f);
    }

    public void NextScene()
    {
        
         SceneManager.LoadScene("Consult2");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
