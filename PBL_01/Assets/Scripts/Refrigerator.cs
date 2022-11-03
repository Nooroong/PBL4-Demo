using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refrigerator : MonoBehaviour
{
    public Button btn;
    public Button Cereal;
    public Button Milk;
    

    // Start is called before the first frame update
    void Start()
    {
        Cereal.GetComponent<Button>().interactable = false;
        Milk.GetComponent<Button>().interactable = false;
        
    }
    public void OnClickButton()
    {
        StartCoroutine(UntilPlayback(btn));
        Cereal.GetComponent<Button>().interactable = true;
        Milk.GetComponent<Button>().interactable = true;
       
    }

    
    IEnumerator UntilPlayback(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        btn.gameObject.SetActive(false);
    }
}
