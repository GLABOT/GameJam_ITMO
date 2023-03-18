using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private LifeSupportSystem _lifeSupportSystem;
    [SerializeField] private CombinationVariables _variable;
    private void Start()
    {
        _lifeSupportSystem = GetComponentInParent<LifeSupportSystem>();
    }
}
