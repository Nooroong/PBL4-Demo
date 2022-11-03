using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeaTime1_sound : MonoBehaviour
{
    public AudioClip audioBoilingwater;
    public AudioClip audioPaperbag;
    public AudioClip audioPourtea;
    public AudioClip audioPourwater;
    //public AudioClip audioBoilingwater;

    public void Paperbag()
    {
        audioSource.clip = audioPaperbag;
        audioSource.Play();
    }
    public void Pourtea()
    {
        audioSource.clip = audioPourtea;
        audioSource.Play();
    }
    public void Boilingwater()
    {
        audioSource.clip = audioBoilingwater;
        audioSource.Play();
    }
    public void Pourwater()
    {
        audioSource.clip = audioPourwater;
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
        Invoke("Paperbag", 3);
        Invoke("Pourtea", 5.25f);
        Invoke("Pourtea", 7.0f);
        Invoke("Boilingwater", 8.0f);
        Invoke("Pourwater", 12.5f);
        Invoke("audioPause", 15.5f);

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
