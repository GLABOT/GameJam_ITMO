using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebootReactor : MonoBehaviour
{
    public static RebootReactor instance;

    bool infoShown = false;
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

    //public void ShowInfo() {
    //    //запуск анимации
    //    Information.instance.ChangeText("Держите R чтобы крутить вентиль");
    //    Information.instance.GetComponent<ShowOrHideUI>().Show();
    //}

    private void Update()
    {
        if (rebooted)
            return;

        //if (!infoShown && rebootStarted)
        //{
        //    ShowInfo();
        //}


        if (rebootStarted)
        {
            if (Input.GetKey(KeyCode.R))
            {
                holdEnded = true;
            }
            else
            {
                holdEnded = false;
            }

            

            if (holdEnded && ButtonDownTimerDelta > 0)
            {
                ButtonDownTimerDelta -= Time.deltaTime;
                Debug.Log("Осталось держать:" + ButtonDownTimerDelta);
            }

            if (ButtonDownTimerDelta <= 0)
            {
                ReactorGame.instance.FixSmoke();
                Information.instance.GetComponent<ShowOrHideUI>().Hide();
                rebooted = true;
                Debug.Log("Успешно!");
                
            }
        }
    }



    
}
