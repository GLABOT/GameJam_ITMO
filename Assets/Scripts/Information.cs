using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Information : MonoBehaviour
{
    public static Information instance = null;

    private TextMeshPro TextMesh;

    private void Start()
    {
        if (instance == null)
            instance = this;

        TextMesh = GetComponent<TextMeshPro>();
    }

    public void ChangeText(string newText)
    {
        TextMesh.text = newText;
    }

    private void ShowText()
    {

    }

    private void HideText()
    {

    }


}
