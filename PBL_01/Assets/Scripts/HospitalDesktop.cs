using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HospitalDesktop : MonoBehaviour
{
    public Button btn;

    public void Questionnaire()
    {
        StartCoroutine(Questionnaire_co(btn));
    }
    
    IEnumerator Questionnaire_co(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        SceneManager.LoadScene("Hospitaltest");
    }
}
