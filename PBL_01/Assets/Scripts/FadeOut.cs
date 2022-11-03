using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public Image Panel;
    public Button new_start_btn;
    public Button continue_btn;

    float time = 0f;
    float F_time = 2f;

    public void F_Out(string scene_name)
    {
        StartCoroutine(FadeOutFlow(scene_name));
    }

    IEnumerator FadeOutFlow(string scene_name)
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
        SceneManager.LoadScene(scene_name);
    }

    public  void Click_Start_Btn() {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("out", 1);
        PlayerPrefs.SetInt("day", 0);
        StartCoroutine(UntilPlayback(new_start_btn, "Prologue_Hospital"));
    }

    public void Click_Continue_Btn() {
        StartCoroutine(UntilPlayback(continue_btn, PlayerPrefs.GetString("Last_scene")));
    }

    
    IEnumerator UntilPlayback(Button obj, string scene_name)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        F_Out(scene_name);
    }

}
