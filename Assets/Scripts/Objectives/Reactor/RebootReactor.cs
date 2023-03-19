using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebootReactor : MonoBehaviour
{
    public static RebootReactor instance;

    [SerializeField] private GameObject m_Valve;
    private Animator _valveAnimator;
    private int _animIDValveAction;

    public bool rebootStarted = false;
    bool holdEnded = false;
    bool rebooted = false;
    
    
    private float ButtonDownTimer = 5;
    private float ButtonDownTimerDelta;

    private void Start()
    {
        if (instance == null)
            instance = this;
        _valveAnimator = m_Valve.GetComponent<Animator>();
        _animIDValveAction = Animator.StringToHash("Interact");
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
                _valveAnimator.SetBool(_animIDValveAction, true);
                Debug.Log("Осталось держать:" + ButtonDownTimerDelta);
            }

            if (ButtonDownTimerDelta <= 0)
            {
                ReactorGame.instance.FixSmoke();
                Information.instance.GetComponent<ShowOrHideUI>().Hide();
                rebooted = true;
                _valveAnimator.SetBool(_animIDValveAction, false);
                Debug.Log("Успешно!");
                SoundsManager.instance.PlaySound("Good", true);
            }
        }
    }



    
}
