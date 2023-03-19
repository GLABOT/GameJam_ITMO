using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentQuest : MonoBehaviour
{
    public static CurrentQuest instance = null;

    ShowOrHideUI questui;

    private Text Text;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        questui = GetComponent<ShowOrHideUI>();
        Text = GetComponent<Text>();
    }

    public void ChangeText(string newText)
    {
        Text.text = newText;
        questui.Show();
    }

    public void HideQuest()
    {
        questui.Hide();
    }


}
