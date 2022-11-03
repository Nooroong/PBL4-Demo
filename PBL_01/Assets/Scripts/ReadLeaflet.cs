using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadLeaflet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("NextScene", 4f);
    }
    public void NextScene()
    {

        SceneManager.LoadScene("StreetPlayer");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
