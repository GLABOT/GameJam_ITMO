using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartObjective : MonoBehaviour
{
    
    void Update()
    {
        float distance;

        distance = Vector3.Distance(Player.instance.transform.position, transform.position);

        if (distance < 2f)
        {

        }
            

    }
}
