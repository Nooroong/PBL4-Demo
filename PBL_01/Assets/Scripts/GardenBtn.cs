using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GardenBtn : MonoBehaviour
{
    public Button Plant1;
    public Button Plant2;
    public Button Plant3;
    public Button Home;
    

    public bool isClicked1 = false;
    public bool isClicked2 = false;
    public bool isClicked3 = false;

    GameObject Memo_ctrl;

    // Start is called before the first frame update
    void Start()
    {
        Home.gameObject.SetActive(false);

        //메모 가져오기
        Memo_ctrl = GameObject.Find("Memo_ctrl");
    }

    // Update is called once per frame
    void Update()
    {
        Select();
    }

    public void IsClicked1()
    {
        isClicked1 = true;
    }

    public void IsClicked2()
    {
        isClicked2 = true;
    }

    public void IsClicked3()
    {
        isClicked3 = true;
    }

    void Select()
    {
        if((isClicked1==true) && (isClicked2==true) && (isClicked3 == true))
        {
            Invoke("Show", 1f);
        }
    }

    void Show()
    {
        Home.gameObject.SetActive(true);
        
    }
    public void Return()
    {
        Complete();
        isClicked1 = false;
        isClicked2 = false;
        isClicked3 = false;
        StartCoroutine(UntilPlayback(Home));  
    }

    public void Complete()
    {
        Memo_ctrl.gameObject.GetComponent<Memo_dontdestroy>().Planter();
    }

    IEnumerator UntilPlayback(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        SceneManager.LoadScene("House");
    }
}
