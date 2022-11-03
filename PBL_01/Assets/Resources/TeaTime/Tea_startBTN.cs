using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tea_startBTN : MonoBehaviour
{
    public Button Teabag1, Teabag2, Teabag3;
    // Start is called before the first frame update
    void Start()
    {
        Teabag1.enabled = false;
        Teabag2.enabled = false;
        Teabag3.enabled = false;
    }
    
    public void OnClick()
    {
        StartCoroutine(OnClick_co());
    }

    IEnumerator OnClick_co()
    {
        this.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !this.GetComponent<AudioSource>().isPlaying);

        this.gameObject.SetActive(false);
        Teabag1.enabled = true; ;
        Teabag2.enabled = true; ;
        Teabag3.enabled = true; ;
    }
}
