using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

//refer: https://epic0n-lib.tistory.com/10

public class Desk_click : MonoBehaviour
{
    string BtnName;
    public Button note, newspaper, home;
    // Start is called before the first frame update


    public void MoveTo() {
        BtnName = EventSystem.current.currentSelectedGameObject.name;

        switch(BtnName) {
            case "Note":
                StartCoroutine(UntilPlayback(note, "Note"));
                break;
            case "Newspaper":
                StartCoroutine(UntilPlayback(newspaper, "Newspaper"));
                break;
            case "Home":
                StartCoroutine(UntilPlayback(home, "House"));
                break;
            default:
                break;
        }
    }


    IEnumerator UntilPlayback(Button obj, string name)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        SceneManager.LoadScene(name);
    }
}
