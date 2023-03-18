using UnityEngine;

public class LifeSupportSystem : MonoBehaviour
{
    public CombinationVariables Variable;

    [SerializeField] private Button firstButton;
    [SerializeField] private Button secondButton;
    [SerializeField] private Button thirdButton;

    public struct Recipe
    {
        public CombinationVariables firstVariable;
        public CombinationVariables secondVariable;
        public CombinationVariables thirdVariable;
    }

    public void PressButton(Button button)
    {
        
    }
}

public enum CombinationVariables { first, second, third }



