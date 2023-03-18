using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Information : MonoBehaviour
{
    public static Information instance = null;

    private Text Text;

    private void Start()
    {
        if (instance == null)
            instance = this;

        Text = GetComponent<Text>();
    }

    public void ChangeText(string newText)
    {
        Text.text = newText;
    }

    public void ShowText()
    {
        gameObject.LeanScale(Vector3.one, .1f).setEaseInBack();
      
    }

    public void HideText()
    {
        gameObject.LeanScale(Vector3.zero, .1f).setEaseInBack();

    }


}
