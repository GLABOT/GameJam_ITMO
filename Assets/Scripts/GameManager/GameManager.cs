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
        //добавить soundmanager и вступительную дорожку
        yield return new WaitForSeconds(5f);
        CurrentQuest.instance.ChangeText("Осмотрите корабль");
        Debug.Log("CheckTheShip!");
        StartCoroutine(WaitForPlayerToCheckTheMap());
    }

    public IEnumerator WaitForPlayerToCheckTheMap()
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(ReactorMiniGame());
    }

    private IEnumerator ReactorMiniGame()
    {
        CurrentQuest.instance.ChangeText("Решите проблему в реакторе");
        SoundAndMusic.instance.NewPolomka();
        TimeForQuests.instance.StartTimer(15);
        yield return new WaitForSeconds(18f);
        StartCoroutine(CourseCorrectionMiniGame());
    }

    private IEnumerator CourseCorrectionMiniGame()
    {
        SoundAndMusic.instance.NewPolomka();
        CurrentQuest.instance.ChangeText("Скорректируйте курс подлодки вручную");
        TimeForQuests.instance.StartTimer(15);
        yield return new WaitForSeconds(18f);
        //след мини игра
    }


    [System.Obsolete]
    public void GameOver()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

