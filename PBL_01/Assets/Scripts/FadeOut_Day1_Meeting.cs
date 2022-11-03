using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut_Day1_Meeting : MonoBehaviour
{
    public Button btn;
    public Image Panel;
    public string nextScene;

    float time = 0f;
    float F_time = 1f;

    public void F_Out()
    {
        PlayerPrefs.SetInt("Rain", 0);
        StartCoroutine(UntilPlayback(btn));
        StartCoroutine(FadeOutFlow());
    }

    IEnumerator FadeOutFlow()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
        SceneManager.LoadScene(nextScene);
    }

    public void Start()
    {
        Panel.gameObject.SetActive(false);

    }

    
    IEnumerator UntilPlayback(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
    }
}
