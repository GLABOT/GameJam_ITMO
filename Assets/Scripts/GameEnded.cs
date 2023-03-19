using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnded : MonoBehaviour
{
    void Start()
    {
        SoundsManager.instance.PlaySound("GoodJob", true);
         StartCoroutine(endsound());
    }

    IEnumerator endsound()
    {
        yield return new WaitForSeconds(2f);
        SoundsManager.instance.PlaySound("End", true);
    }
}
