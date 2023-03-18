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
            RebootReactor.instance.Reboot();


    }
}
