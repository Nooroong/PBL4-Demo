using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut_Hospital_lobby : MonoBehaviour
{
    public Image Panel;
    public Image Background;

    float time = 0f;
    float F_time = 1f;

    public void F_Out() {
        StartCoroutine(FadeOutFlow());
    }

    IEnumerator FadeOutFlow() {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;

        while (alpha.a < 1f) {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
        NextScene();
    }
    void NextScene() {
        SceneManager.LoadScene("hospitaldesktop");
    }
}
