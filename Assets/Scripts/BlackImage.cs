using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackImage : MonoBehaviour
{
    public static BlackImage instance = null;

    Image image;


    private void Start()
    {
        if (instance == null)
            instance = this;

        image = GetComponent<Image>();
    }


    public void Blacked()
    {
        LeanTween.textColor(image.GetComponent<RectTransform>(), new Color32(0, 0, 0, 255), 1f);
    }


}
