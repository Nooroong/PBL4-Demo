using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_btn2 : MonoBehaviour
{
    public GameObject parent; //±×¸®µå
    private int childCount;

    public GameObject circuit;

    public Button hint_btn;
    public Image black;

    // Start is called before the first frame update
    void Start()
    {
        circuit.gameObject.GetComponent<Components_check2>().enabled = false;

        hint_btn.gameObject.SetActive(false);
        black.enabled = true;

        childCount = parent.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            parent.transform.GetChild(i).gameObject.GetComponent<Component_movement>().enabled = false;
        }
    }

    // Update is called once per frame
    public void Onclick()
    {
        StartCoroutine(UntilPlayback(this.GetComponent<Button>()));

        circuit.gameObject.GetComponent<Components_check2>().enabled = true;

        hint_btn.gameObject.SetActive(true);

        black.enabled = false;
    }

        
    IEnumerator UntilPlayback(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        this.gameObject.SetActive(false);
    }
}
