using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicators : MonoBehaviour
{
    [SerializeField] private Image[] m_Images;
    [SerializeField] private Sprite m_TexturePrefabRed;
    [SerializeField] private Sprite m_TexturePrefabGreen;
    [SerializeField] private Sprite m_TexturePrefabBlue;
    [SerializeField] private Sprite m_TexturePrefabEmpty;

    [SerializeField] private float m_HideIndicatorsTime = 3f;

    public void SetIndicatorsColor(List<Ingredients> ingredients)
    {
        for (int i = 0; i < ingredients.Count; i++)
        {
            if (ingredients[i] == Ingredients.Red) m_Images[i].sprite = m_TexturePrefabRed;
            else if (ingredients[i] == Ingredients.Green) m_Images[i].sprite = m_TexturePrefabGreen;
            else if (ingredients[i] == Ingredients.Blue) m_Images[i].sprite = m_TexturePrefabBlue;
            else m_Images[i].sprite = m_TexturePrefabEmpty;
        }

        StartCoroutine(HideIndicators());
    }

    private IEnumerator HideIndicators()
    {
        yield return new WaitForSeconds(m_HideIndicatorsTime);

        foreach (Image image in m_Images)
        {
            image.sprite = m_TexturePrefabEmpty;
        }
    }
}
