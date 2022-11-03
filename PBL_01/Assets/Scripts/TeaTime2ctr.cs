using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeaTime2ctr : MonoBehaviour
{
    public Button home;
    public GameObject Bar;

    GameObject Memo_ctrl;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<ListenForAudioCommand>().enabled = false;
        text.SetActive(false);
        home.interactable = false;

        Invoke("GaugeBarCtrl", 4.5f);

        //메모 가져오기
        Memo_ctrl = GameObject.Find("Memo_ctrl");
    }

    // Update is called once per frame
    void Update()
    {
        if(Bar.GetComponent<Image>().fillAmount == 1)
        {
            home.interactable = true;
        }
    }

    public void LoadHome()
    {
        StartCoroutine(LoadHome_co(home));
    }
    
    public void Complete()
    {
        Memo_ctrl.gameObject.GetComponent<Memo_dontdestroy>().Tea();
    }

    public void GaugeBarCtrl()
    {
        text.SetActive(true);
        this.gameObject.GetComponent<ListenForAudioCommand>().enabled = true;
    }


    IEnumerator LoadHome_co(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);

        Complete();
        PlayerPrefs.SetInt("Tea", 0);
        SceneManager.LoadScene("House");
    }
}
