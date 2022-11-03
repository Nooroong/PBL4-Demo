using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class choosetea : MonoBehaviour
{
    public static string tea;
    private GameObject clickedObj; //클릭한 오브젝트
    

    public void MoveToTeaTime() {
        //클릭한 오브젝트 가져오고 코루틴 실행
        clickedObj = EventSystem.current.currentSelectedGameObject;
        StartCoroutine(MoveToTeaTime_co(clickedObj));
    }

    public void LoadHome()
    {
        StartCoroutine(LoadHome_co(GameObject.Find("Home")));
    }



    IEnumerator MoveToTeaTime_co(GameObject obj)
    {
        tea = obj.name; //선택한 오브젝트 이름 가져오기

        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        
        SceneManager.LoadScene("TeaTime1");
    }

    IEnumerator LoadHome_co(GameObject obj)
    {
        PlayerPrefs.SetInt("Tea", 0);

        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        
        SceneManager.LoadScene("House");
    }
}
