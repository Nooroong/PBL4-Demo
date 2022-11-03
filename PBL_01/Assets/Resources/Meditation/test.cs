using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    GameObject Memo_ctrl;

    public AudioSource Alarm;

    float time = 0f;
    int cnt = 0;
    public void Start()
    {
        //메모 가져오기
        Memo_ctrl = GameObject.Find("Memo_ctrl");
    }
    public void Complete()
    {
        Memo_ctrl.gameObject.GetComponent<Memo_dontdestroy>().Meditation();
    }
    public void Moving()
    {
        StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        while (true)
        { 
            time += Time.deltaTime;
            transform.Translate(Vector2.up *0.935f* Time.deltaTime); // 기존 값: 0.9f
            
            if(time >= 2f)
            {
                Alarm.Play();
                if ( cnt == 4 || cnt == 5)
                {
                    time = 0f;
                    cnt++;
                    yield return new WaitForSeconds(2f);
                }
                else if (cnt == 14)
                {
                    break;
                }
                else
                {
                    time = 0f;
                    cnt++;
                    yield return new WaitForSeconds(10f);
                }
            }
            yield return null;
        }
        Complete();
    }

}
