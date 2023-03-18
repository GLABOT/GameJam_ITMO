using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartObjective : MonoBehaviour
{
    bool IsShown;
    bool ObjectiveStarted;

    void Update()
    {
        float distance;

        distance = Vector3.Distance(Player.instance.transform.position, transform.position);
        Debug.Log(distance);

        if (ObjectiveStarted)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed");
            Information.instance.HideText();
            ObjectiveStarted = true;
            return;
        }

        if (distance < 2)
        {
            if (!IsShown)
            {
                Information.instance.ChangeText("Нажмите E");
                Information.instance.ShowText();
                IsShown = true;
            }
        }
        else
        {
            if(IsShown)
            {
                Information.instance.HideText();
                IsShown = false;
            }
        }

    }
}
