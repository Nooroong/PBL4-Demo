using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cereal : MonoBehaviour
{
    public Button cereal;
    public AudioSource audioSource;
    public AudioClip bgm;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm;
        audioSource.loop = false;
    }

    // Start is called before the first frame update

    public void Sound()
    {
        audioSource.Play();
        Invoke("Hide", 0.5f);
    }
    public void Hide()
    {
        cereal.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
