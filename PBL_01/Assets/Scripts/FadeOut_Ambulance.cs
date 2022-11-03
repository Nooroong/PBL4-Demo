using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut_Ambulance : MonoBehaviour
{
    // Start is called before the first frame update
    public Image Panel;
    public Image Background;
    public GameObject audio_source;


    float time = 0f;
    float F_time = 2f;

    public void Start()
    {
        Invoke("F_Out", 3f);
    }

    public void F_Out()
    {
        StartCoroutine(FadeOutFlow());
    }

    IEnumerator FadeOutFlow()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;
        float vol = 1;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            vol = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            audio_source.GetComponent<AudioSource>().volume = vol; //effect sound fade out.
            yield return null;
        }
        yield return null;
        SceneManager.LoadScene("BandS");
    }
}
