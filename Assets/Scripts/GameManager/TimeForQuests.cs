using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeForQuests : MonoBehaviour
{
    public static TimeForQuests instance = null;

    ShowOrHideUI timerui;
    float TimerDelta = 10f;           //переменная будет уменьшаться 
    Text text;

    bool timerStarted = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        timerui = GetComponent<ShowOrHideUI>();
        text = GetComponent<Text>();
    }

    public void StartTimer(int sec)
    {
        TimerDelta = sec;
        timerStarted = true;
        timerui.Show();
    }

    public void StopTimer()
    {
        timerStarted = false;
        TimerDelta = 30;
        timerui.Hide();
    }

    private void Update()
    {
        if (!timerStarted)
            return;

        if (TimerDelta > 0)
        {
            TimerDelta -= Time.deltaTime;
            text.text = "" + TimerDelta;
        }

        if (TimerDelta <= 0)
        {
            GameManager.instance.GameOver();
        }
    }
}
