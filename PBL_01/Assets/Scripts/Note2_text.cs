using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Note2_text : MonoBehaviour
{
    public Text text;
    public Text note, ps;
    public Button exit;

    // Start is called before the first frame update
    void Start()
    {
        text.text = PlayerPrefs.GetString("note");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Exit()
    {
        StartCoroutine(Exit_co(exit));
    }

    IEnumerator Exit_co(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        PlayerPrefs.SetInt("NoteCp", 1);
        SceneManager.LoadScene("desk");
    }
}
