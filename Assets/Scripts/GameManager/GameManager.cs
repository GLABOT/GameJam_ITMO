using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private void Start()
    {
        if (instance == null)
            instance = this;



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
        yield return new WaitForSeconds(30f);
        StartCoroutine(ReactorMiniGame());
    }

    private IEnumerator ReactorMiniGame()
    {
        SoundsManager.instance.PlaySound("ReactorTrouble",true);
        CurrentQuest.instance.ChangeText("Решите проблему в реакторе");
        SoundsManager.instance.PlaySound("Signal", true);
        TimeForQuests.instance.StartTimer(20);
        yield return new WaitForSeconds(30f);
        StartCoroutine(CourseCorrectionMiniGame());
    }

    private IEnumerator CourseCorrectionMiniGame()
    {
        SoundsManager.instance.PlaySound("CursError", true);
        SoundsManager.instance.PlaySound("Signal", true);
        CurrentQuest.instance.ChangeText("Скорректируйте курс подлодки вручную");
        TimeForQuests.instance.StartTimer(15);
        yield return new WaitForSeconds(18f);
        StartCoroutine(TurnOnTheLight());
    }

    private IEnumerator TurnOnTheLight()
    {
        SoundsManager.instance.PlaySound("Signal", true);
        CurrentQuest.instance.ChangeText("Включите свет, перезапустив генератор");
        TimeForQuests.instance.StartTimer(20);
        yield return new WaitForSeconds(25f);
        StartCoroutine(HealthProblems());
    }

    private IEnumerator HealthProblems()
    {
        SoundsManager.instance.PlaySound("Signal", true);
        CurrentQuest.instance.ChangeText("Исправьте систему жизнеобеспечения");
        SoundsManager.instance.PlaySound("HealthSupport", true);
        TimeForQuests.instance.StartTimer(20);
        yield return new WaitForSeconds(25f);
        
    }

   



    [System.Obsolete]
    public void GameOver()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

