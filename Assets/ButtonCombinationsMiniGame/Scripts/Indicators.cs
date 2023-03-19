using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicators : MonoBehaviour
{
    [SerializeField] private Image[] m_Images;

    public void SetIndicatorsColor(List<Ingredients> ingredients)
    {
        for (int i = 0; i < ingredients.Count; i++)
        {
            if (ingredients[i] == Ingredients.Red) m_Images[i].color = Color.red;
            else if (ingredients[i] == Ingredients.Green) m_Images[i].color = Color.green;
            else if (ingredients[i] == Ingredients.Blue) m_Images[i].color = Color.blue;
            else m_Images[i].color = Color.clear;
        }
    }
}
