using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnCtl : MonoBehaviour
{
    public GameObject cam, stick; 

    // Start is called before the first frame update
    void Start()
    {
        cam.transform.gameObject.GetComponent<MaskCamera>().enabled = false;
        stick.transform.gameObject.GetComponent<Drag>().enabled = false;
    }

    // Update is called once per frame
    public void Onclick()
    {
        StartCoroutine(Onclick_co(this.GetComponent<Button>()));
    }

    IEnumerator Onclick_co(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        this.gameObject.SetActive(false);
        cam.transform.gameObject.GetComponent<MaskCamera>().enabled = true;
        stick.transform.gameObject.GetComponent<Drag>().enabled = true;
    }
}
