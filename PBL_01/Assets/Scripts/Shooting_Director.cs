using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shooting_Director : MonoBehaviour
{
    public GameObject gauge;
    public GameObject mark1, mark2, mark3, mark4;
    public GameObject targets;
    public GameObject timer;
    public GameObject Joystick;
    public Image black;
    public Button shoot;
    public AudioSource obj;
    float timeRemain;
    bool flag = true; //게임 오버 시 효과음이 무한재생되는 문제 해결 용
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeRemain = timer.gameObject.GetComponent<Timer>().timeRemain();
        
        if(timeRemain != 0)
        {
            if (gauge.GetComponent<Image>().fillAmount == 1f)
            {
                timer.gameObject.GetComponent<Timer>().NailedGame();
                StopGame();
                Invoke("NextScene", 4f);
            }
        }
        else
        {
            if(flag) {
                StopGame();
                StartCoroutine(UntilPlayback(obj));
                flag = !flag;
            }
            
        }

    }
    public void gaugeUp()
    {
        gauge.GetComponent<Image>().fillAmount += 0.25f;
    }
    public void StopGame()
    {
        Joystick.gameObject.GetComponent<Joystick_shooting>().timeIsZero();
        Joystick.gameObject.GetComponent<Joystick_shooting>().enabled = false;
        targets.gameObject.GetComponent<Target_move>().Stop();
        shoot.enabled = false;
        black.gameObject.SetActive(true);
        black.gameObject.GetComponent<FadeOut_shooting>().enabled = true;
    }
    public void AgainScene()
    {
        SceneManager.LoadScene("Shooting_game");
    }
    public void NextScene()
    {
        SceneManager.LoadScene("Celebration");
    }

    IEnumerator UntilPlayback(AudioSource obj)
    {
        obj.Play();
        yield return new WaitUntil(() => !obj.isPlaying);
        AgainScene();
    }
}
