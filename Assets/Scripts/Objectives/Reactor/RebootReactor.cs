using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebootReactor : MonoBehaviour
{
    public static RebootReactor instance;

    public bool rebootStarted = false;
    bool holdEnded = false;
    bool rebooted = false;
    
    
    private float ButtonDownTimer = 5;
    private float ButtonDownTimerDelta;

    private void Start()
    {
        if (instance == null)
            instance = this;

        ButtonDownTimerDelta = ButtonDownTimer;
    }

    private void Update()
    {
        if (rebooted)
            return;


        if (rebootStarted)
        {
            if (Input.GetKey(KeyCode.R))
                holdEnded = true;
            else
                holdEnded = false;

            

            if (holdEnded && ButtonDownTimerDelta > 0)
            {
                //SoundAndMusic.instance.SpinCircle();
                ButtonDownTimerDelta -= Time.deltaTime;
                SoundAndMusic.instance.SpinCircle();
                StartCoroutine(SoundManager.instance.StopAudioInSecond());
                Debug.Log("Осталось держать:" + ButtonDownTimerDelta);
            }

            if (ButtonDownTimerDelta <= 0)
            {
                ReactorGame.instance.FixSmoke();
                Information.instance.GetComponent<ShowOrHideUI>().Hide();
                rebooted = true;
                Debug.Log("Успешно!");
                StartCoroutine(SoundManager.instance.StopAudioInSecond());
                SoundAndMusic.instance.ReactorNice();
                StartCoroutine(SoundManager.instance.StopAudioInSecond());

            }
        }
    }



    
}
