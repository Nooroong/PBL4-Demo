using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StitchStartBtn : MonoBehaviour
{
    public GameObject parent; //±×¸®µå

    // Start is called before the first frame update
    void Start() {
        parent.transform.gameObject.GetComponent<LockPattern>().enabled = false;
    }

    // Update is called once per frame
    public void Onclick() {
        StartCoroutine(UntilPlayback(this.GetComponent<Button>()));
    }

    IEnumerator UntilPlayback(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        this.gameObject.SetActive(false);
        parent.transform.gameObject.GetComponent<LockPattern>().enabled = true;
    }
}
