using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Refri_Home : MonoBehaviour
{
    public Button cereal;
    public Button milk;
    public Button home;

    public bool isClicked1 = false;
    public bool isClicked2 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void IsClicked1()
    {
        isClicked1 = true;
        HouseCollisionCheck.click1 = isClicked1;
    }

    public void IsClicked2()
    {
        isClicked2 = true;
        HouseCollisionCheck.click2 = isClicked2;
    }
    public void Return()
    {
        StartCoroutine(Return_co(home));
        
    }

    
    IEnumerator Return_co(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        SceneManager.LoadScene("House");
    }

}
