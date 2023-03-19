using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Ingredients m_ingredient;
    private LifeSupportSystem _lifeSupportSystem;

    private void Awake()
    {
        _lifeSupportSystem = GetComponentInParent<LifeSupportSystem>();
    }

    public Ingredients Ingredient { get { return m_ingredient; } }

    public void PressAddButton()
    {
        _lifeSupportSystem.CurrentIngredients.Add(m_ingredient);
    }

    public void PressMixButton()
    {
        _lifeSupportSystem.MixIngredients();
    }
    
    public void PressClearButton()
    {
        _lifeSupportSystem.CurrentIngredients.Clear();
    }
}
