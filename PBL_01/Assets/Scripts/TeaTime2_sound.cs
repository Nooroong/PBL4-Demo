using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaTime2_sound : MonoBehaviour
{
    public AudioClip audioPourtea;
    //public AudioClip audioBoilingwater;

    public void Pourtea()
    {
        audioSource.clip = audioPourtea;
        audioSource.Play();
    }
    public void audioPause()
    {
        audioSource.Pause();
    }
    AudioSource audioSource;
    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
        Pourtea();
        Invoke("audioPause", 4.5f);

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
