using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOrHideUI : MonoBehaviour
{
    private float messageTime = 2f;

    public void Show()
    {
        gameObject.LeanScale(Vector3.one, .1f).setEaseInBack();
        Debug.Log(gameObject.name + "  showed");

    }

    public void Hide()
    {
        gameObject.LeanScale(Vector3.zero, .1f).setEaseInBack();
        Debug.Log(gameObject.name + "  hided");
    }

    public IEnumerator ShowAsMessage()
    {
        Show();
        yield return new WaitForSeconds(messageTime);
        Hide();
    }
}
