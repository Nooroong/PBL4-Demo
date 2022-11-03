using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    public Text timeText;
    // Start is called before the first frame update
    private void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                timeText.text = "Time Out!";
            }
        }
    }
    public float timeRemain()
    {
        return timeRemaining;
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay);
        float m_seconds = Mathf.FloorToInt((timeToDisplay-seconds)*100);
        timeText.text = string.Format("{0:00}:{1:00}", seconds, m_seconds);
    }

    public void NailedGame()
    {
        timerIsRunning = false;
    }
}
