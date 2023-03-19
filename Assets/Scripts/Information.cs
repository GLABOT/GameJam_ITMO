using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Information : MonoBehaviour
{
    public static Information instance = null;

    private ShowOrHideUI infoui;
    private Text Text;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        infoui = GetComponent<ShowOrHideUI>();
        Text = GetComponent<Text>();
    }

    public void ChangeText(string newText)
    {
        Text.text = newText;
        infoui.Show();
    }

    public void HideInfo()
    {
        infoui.Hide();
    }


}
