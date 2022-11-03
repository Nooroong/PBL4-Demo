using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StreetLeaflet : MonoBehaviour
{
    public Button btn;

    public void Leaflet()
    {
        StartCoroutine(Leaflet_co(btn));
    }

    // Update is called once per frame
    IEnumerator Leaflet_co(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        SceneManager.LoadScene("ReadLeaflet");
    }
}
