using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeryStartBtn : MonoBehaviour {
    public GameObject parent; //±×¸®µå
    private int childCount;

    // Start is called before the first frame update
    void Start() {
        childCount = parent.transform.childCount;
        for (int i = 0; i < childCount; i++) {
            parent.transform.GetChild(i).gameObject.GetComponent<MemoryMovement>().enabled = false;
        }
    }

    // Update is called once per frame
    public void Onclick() {
        StartCoroutine(Onclick_co(this.gameObject));
    }

    IEnumerator Onclick_co(GameObject obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);

        this.gameObject.SetActive(false);
        for (int i = 0; i < childCount; i++) {
            parent.transform.GetChild(i).gameObject.GetComponent<MemoryMovement>().enabled = true;
        }
    }
}
