using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meditation_start : MonoBehaviour
{
    public GameObject Text;
    public GameObject home;
    // Start is called before the first frame update
    void Start()
    {
        //Text.gameObject.GetComponent<test>().enabled = false;
    }

    public void Onclick()
    {
        StartCoroutine(OnClick_co(this.GetComponent<Button>()));
    }

    IEnumerator OnClick_co(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        this.gameObject.SetActive(false);
        //Text.gameObject.GetComponent<test>().enabled = true;
        Text.gameObject.GetComponent<test>().Moving();
        home.gameObject.GetComponent<Meditation_home>().Interactive();
    }
}
