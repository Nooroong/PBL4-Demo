using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneStartBtn : MonoBehaviour
{
    public GameObject parent;
    private int childCnt;

    // Start is called before the first frame update
    void Start()
    {
        childCnt = parent.transform.childCount;
        for(int i = 0; i < childCnt; i++) {
            parent.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }
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
        for (int i = 0; i < childCnt; i++) {
            parent.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }
    }
}
