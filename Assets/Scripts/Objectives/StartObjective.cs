using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartObjective : MonoBehaviour
{
    [SerializeField]
    private string ObjectiveText = "Нажмите E";
    [SerializeField]
    private KeyCode button;

    private Objective objective;

    bool IsShown;
    bool ObjectiveStarted;

    ShowOrHideUI InformationManager;

    private void Start()
    {
        objective = GetComponent<Objective>();
        InformationManager = Information.instance.GetComponent<ShowOrHideUI>();
    }

    void Update()
    {
        float distance;

        distance = Vector3.Distance(Player.instance.transform.position, transform.position);

        if (ObjectiveStarted)
            return;

        

        if (distance < 2)
        {
            if (Input.GetKeyDown(button))
            {
                InformationManager.Hide();
                objective.StartObjective();
                ObjectiveStarted = true;
                return;
            }

            if (!IsShown)
            {
                Information.instance.ChangeText(ObjectiveText);
                InformationManager.Show();
                IsShown = true;
            }
        }
        else
        {
            if(IsShown)
            {
                InformationManager.Hide();
                IsShown = false;
            }
        }

    }
}
