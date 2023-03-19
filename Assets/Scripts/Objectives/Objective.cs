using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
   public void StartObjective()
    {
        if (gameObject.tag == "Reactor")
            ReactorGame.instance.miniGameStarted = true;

        if (gameObject.tag == "RebootReactor")
            RebootReactor.instance.rebootStarted = true;

        if (gameObject.tag == "CourseControl")
        {
            StartCoroutine(CourseControl.instance.ShowCourse());
        }

        if (gameObject.tag == "Clicker")
        {
            ClickerMiniGame.instance.ClickerStarted = true;
            ClickerMiniGame.instance.GetComponent<ShowOrHideUI>().Show();
            Information.instance.ChangeText("Нажимайте на R много раз!");
        }

        if (gameObject.tag == "Health")
        {
            //GameObject.FindGameObjectWithTag("SceneController").GetComponent<FadeInOut>().LoadScene("");
        }


    }
}
