using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListenForAudioCommand : MonoBehaviour
{
    public GameObject Bar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float db = 20 * Mathf.Log10(Mathf.Abs(mic_volume.MicLoudness));

        if (db < 1 && db > -20f)
        {
            IncreaseBar();
        }
    }
    public void IncreaseBar()
    {
        Bar.GetComponent<Image>().fillAmount += 0.003f;
    }
}
