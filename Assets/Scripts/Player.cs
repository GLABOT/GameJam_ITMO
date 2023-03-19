using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;

    }
}
