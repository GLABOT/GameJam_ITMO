using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public static ParticleSpawner instance = null;

    private void Start()
    {
        if (instance == null)
            instance = this;
    }

    public GameObject Smoke;
}
