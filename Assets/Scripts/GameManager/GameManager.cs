using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public StartObjective Reactor;
    public StartObjective CourseControl;
    public StartObjective Submarine;
    public StartObjective Clicker;
    public StartObjective Ventil;

    private void Start()
    {
        if (instance == null)
            instance = this;

        Reactor.enabled = false;
        CourseControl.enabled = false;
        Submarine.enabled = false;
        Clicker.enabled = false;
        Ventil.enabled = false;

        StartCoroutine(ListenIntro());
    }

    IEnumerator ListenIntro()
    {
        CurrentQuest.instance.ChangeText("Послушайте оператора");
        SoundsManager.instance.PlaySound("Welcome", true);
        //добавить soundmanager и вступительную дорожку
        yield return new WaitForSeconds(8f);
        CurrentQuest.instance.ChangeText("Осмотрите корабль");
        SoundsManager.instance.PlaySound("HowItGoes", true);
        Debug.Log("CheckTheShip!");
        StartCoroutine(WaitForPlayerToCheckTheMap());
    }


    public IEnumerator WaitForPlayerToCheckTheMap()
    {
        yield return new WaitForSeconds(45f);
        Reactor.enabled = true;
        Ventil.enabled = true;
        StartCoroutine(ReactorMiniGame());
    }

    private IEnumerator ReactorMiniGame()
    {
        SoundsManager.instance.PlaySound("ReactorTrouble",true);
        CurrentQuest.instance.ChangeText("Решите проблему в реакторе");
        SoundsManager.instance.PlaySound("Signal", true);
        TimeForQuests.instance.StartTimer(45);
        yield return new WaitForSeconds(60f);
        CourseControl.enabled = true;
        StartCoroutine(CourseCorrectionMiniGame());
    }

    private IEnumerator CourseCorrectionMiniGame()
    {
        SoundsManager.instance.PlaySound("CursError", true);
        SoundsManager.instance.PlaySound("Signal", true);
        CurrentQuest.instance.ChangeText("Скорректируйте курс подлодки вручную");
        TimeForQuests.instance.StartTimer(40);
        yield return new WaitForSeconds(50f);
        Clicker.enabled = true;
        StartCoroutine(TurnOnTheLight());
    }

    private IEnumerator TurnOnTheLight()
    {
        SoundsManager.instance.PlaySound("Signal", true);
        CurrentQuest.instance.ChangeText("Включите свет, перезапустив генератор");
        TimeForQuests.instance.StartTimer(35);
        yield return new WaitForSeconds(45f);
        Submarine.enabled = true;
        StartCoroutine(HealthProblems());
    }

    private IEnumerator HealthProblems()
    {
        SoundsManager.instance.PlaySound("Signal", true);
        CurrentQuest.instance.ChangeText("На нас напали! Бегите в отсек с торпедами!");
        SoundsManager.instance.PlaySound("Torpedo", true);
        TimeForQuests.instance.StartTimer(35);
        yield return new WaitForSeconds(45f);
        
    }

   



    [System.Obsolete]
    public void GameOver()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

