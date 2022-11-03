using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleStartBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Onclick()
    {
        StartCoroutine(UntilPlayback(this.GetComponent<Button>()));
    }


    IEnumerator UntilPlayback(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        this.gameObject.SetActive(false);
    }
}
