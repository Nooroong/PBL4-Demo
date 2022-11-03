using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Next_btn : MonoBehaviour
{
    public GameObject components;
    public Button next;
   
    public GameObject circuit;
    public Button hint_btn;
    public Image complete;

    int next_cnt = 0;

    float time = 0f;
    float F_time = 2f;

    public void Onclick()
    {
        StartCoroutine(UntilPlayback(next));

        next_cnt++;

        if (next_cnt < 2)
        {
            circuit.gameObject.SetActive(false);
            components.gameObject.SetActive(false);
            hint_btn.gameObject.SetActive(false);

            Invoke("FadeIn", 1f);
        }
        else
        {
            SceneManager.LoadScene("Assemble_game2");
        }
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInFlow());
    }

    IEnumerator FadeInFlow()
    {
        complete.gameObject.SetActive(true);
        time = 0f;
        Color alpha = complete.color;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            complete.color = alpha;
            yield return null;
        }
        yield return null;
    }

        
    IEnumerator UntilPlayback(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
    }
}
