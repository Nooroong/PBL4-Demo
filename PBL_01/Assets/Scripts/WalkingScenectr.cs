using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WalkingScenectr : MonoBehaviour
{
    public Button start, finish, Home;
    Animator m_Animator;

    GameObject Memo_ctrl;

    // Start is called before the first frame update
    void Start()
    {
        finish.gameObject.SetActive(false);
        finish.enabled = false;
        Home.enabled = false;
        m_Animator = GetComponent<Animator>();
        m_Animator.GetComponent<Animator>().enabled = false;

        //메모 가져오기
        Memo_ctrl = GameObject.Find("Memo_ctrl");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startWalk()
    {
        m_Animator.GetComponent<Animator>().enabled = true;
        finish.gameObject.SetActive(true);
        finish.enabled = true;
        StartCoroutine("Destory_Btn");
    }
    public void finishWalk()
    {
        m_Animator.GetComponent<Animator>().enabled = false;
        Home.enabled = true;
    }
    public void LoadHouse()
    {
        StartCoroutine(LoadHouse_co(Home));
    }
    public void Complete()
    {
        Memo_ctrl.gameObject.GetComponent<Memo_dontdestroy>().Walking();
    }

    //효과음 재생 뒤에 오브젝트 비활성화
    IEnumerator Destory_Btn() {
        yield return new WaitForSeconds(0.15f);
        if(!start.GetComponent<AudioSource>().isPlaying)
            start.gameObject.SetActive(false);
    }

    IEnumerator LoadHouse_co(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);

        SceneManager.LoadScene("House");
        Complete();
    }

}
