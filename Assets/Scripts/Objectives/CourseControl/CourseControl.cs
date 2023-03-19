using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CourseControl : MonoBehaviour
{
    public static CourseControl instance = null;

    private Text Primer;

    int numberOfErrors = 0;

    bool Answer1;
    bool Answer2;
    bool Answer3;

    string Primer1 = "4x-16=0";
    string Primer2 = "y+x=5";
    string Primer3 = "z-y-x=0";

    public bool courseStarted;
    bool finalCheck;



    private void Start()
    {
        if (instance == null)
            instance = this;

        Primer = transform.GetChild(0).GetComponent<Text>();

        Primer.text = Primer1;
    }

    public IEnumerator ShowCourse()
    {
        yield return new WaitForSeconds(0.3f);
        courseStarted = true;
        GetComponent<ShowOrHideUI>().Show();
        SoundsManager.instance.PlaySound("Math",true);
    }

    private void Update()
    {
        if (!courseStarted)
            return;


        if (Input.GetKeyDown(KeyCode.Alpha4) && !Answer1)
        {
            Primer.text = Primer2;
            Answer1 = true;
            return;
        } 
        

        
        if (Answer1 && Input.GetKeyDown(KeyCode.Alpha1) && !Answer2)
        {
            Answer2 = true;
            Primer.text = Primer3;
        }


        if (Answer1 && Answer2 && Input.GetKeyDown(KeyCode.Alpha5) && !Answer3)
        {
            Answer3 = true;
            finalCheck = true;
        }



        if (finalCheck)
            finalCheckout();


    }

    private void finalCheckout()
    {
        finalCheck = false;

        if (Answer1 && Answer2 && Answer3)
        {
            Debug.Log("Все ответы верны!");
            GetComponent<ShowOrHideUI>().Hide();
            Information.instance.ChangeText("Вы верно нашли все три координаты и поправили курс корабля!");
            StartCoroutine(Information.instance.GetComponent<ShowOrHideUI>().ShowAsMessage());

            TimeForQuests.instance.StopTimer();
            CurrentQuest.instance.HideQuest();
            SoundsManager.instance.PlaySound("Math", false);
            SoundsManager.instance.PlaySound("Signal", false);
            SoundsManager.instance.PlaySound("Good", true);

        }
        
    }



}
