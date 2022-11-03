using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
    Stopwatch stopWatch;
    TimeSpan ts;
    public bool timerIsRunning = false;
    public float time = 0f;
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        stopWatch = new Stopwatch();
        ts = stopWatch.Elapsed;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            ts = stopWatch.Elapsed;
            timeText.text = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
        }
    }
    void TimeRunning()
    {
        timeText.text = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
    }
    public void StartWalking()
    {
        timerIsRunning = true;
        stopWatch.Start();
        TimeRunning();
    }
    public void StopWalking()
    {
        timerIsRunning = false;
        stopWatch.Stop();
    }

}
