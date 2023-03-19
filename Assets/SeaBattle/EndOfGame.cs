using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundsManager.instance.PlaySound("GoodJob", true);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
        SoundsManager.instance.PlaySound("End", true);
    }

    
}
