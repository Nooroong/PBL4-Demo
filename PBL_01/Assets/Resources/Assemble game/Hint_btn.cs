using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint_btn : MonoBehaviour
{
    public Image hint;
    public Image black;
    int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        hint.enabled = false;
        black.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Onclick()
    {
        StartCoroutine(UntilPlayback(this.GetComponent<Button>()));

        cnt++;
        if (cnt % 2 == 0)
        {
            hint.enabled = false;
            black.enabled = false;
            this.GetComponent<Image>().sprite = Resources.Load("Assemble game\\close", typeof(Sprite)) as Sprite;
        }
        else
        {
            hint.enabled = true;
            black.enabled = true;
            this.GetComponent<Image>().sprite = Resources.Load("Assemble game\\open", typeof(Sprite)) as Sprite;
        }
    }

        
    IEnumerator UntilPlayback(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
    }
}
