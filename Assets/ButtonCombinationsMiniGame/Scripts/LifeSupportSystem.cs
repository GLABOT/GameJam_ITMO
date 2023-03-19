using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LifeSupportSystem : MonoBehaviour
{
    private Indicators _indicators;

    private List<Ingredients> _targetIngredients = new List<Ingredients>();
    private List<Ingredients> _currentIngredients = new List<Ingredients>();
    public List<Ingredients> CurrentIngredients { get { return _currentIngredients; } set { _currentIngredients = value; } }

    [SerializeField] private float m_ExitTimer = 1.5f;

    [SerializeField] private GameObject m_Message;

    private string _winMessage = "Отлично!";
    private string _loseMessage = "Не получилось";

    private void Awake()
    {
        _indicators = GetComponentInChildren<Indicators>();
    }

    private void Start()
    {
        TriggerLifeSupportSystem(); // REMOVE 
    }

    public void MixIngredients()
    {
        if (_currentIngredients.Count == _targetIngredients.Count)
        {
            for (int i = 0; i < _currentIngredients.Count; i++)
            {
                if (_currentIngredients[i] != _targetIngredients[i])
                {
                    Lose();
                    return;
                }
            }

            Win();
        }
        else
        {
            Lose();
        }
    }

    private void RandomCombinatrion()
    {
        int combination = Random.Range(0, 5);

        if (combination == 0)
        {
            FirstCombintionation();
            return;
        }
        if (combination == 1)
        {
            SecondCombintionation();
            return; 
        }
        if (combination == 2)
        {
            ThirdCombintionation();
            return;
        }
        if (combination == 3)
        {
            ThirdCombintionation();
            return;
        }
        else
        {
            FithCombintionation();
            return;
        }
    }

    private void Lose()
    {
        m_Message.SetActive(true);
        m_Message.GetComponentInChildren<Text>().text = _loseMessage;
        StartCoroutine(ExitMiniGame());
    }

    private void Win()
    {
        m_Message.SetActive(true);
        m_Message.GetComponentInChildren<Text>().text = _winMessage;
        StartCoroutine(ExitMiniGame());
    }

    private IEnumerator ExitMiniGame()
    {
        yield return new WaitForSeconds(m_ExitTimer);
        m_Message.SetActive(false);
        gameObject.SetActive(false);
    }

    public void TriggerLifeSupportSystem()
    {
        _currentIngredients.Clear();
        RandomCombinatrion();
        _indicators.SetIndicatorsColor(_targetIngredients);
    }

    private void FirstCombintionation()
    {
        _targetIngredients.Add(Ingredients.Red);
        _targetIngredients.Add(Ingredients.Blue);
        _targetIngredients.Add(Ingredients.Green);
    }

    private void SecondCombintionation()
    {
        List<Ingredients> ingredients = new List<Ingredients>();
        _targetIngredients.Add(Ingredients.Green);
        _targetIngredients.Add(Ingredients.Blue);
        _targetIngredients.Add(Ingredients.Green);
        _targetIngredients.Add(Ingredients.Red);
    }

    private void ThirdCombintionation()
    {
        List<Ingredients> ingredients = new List<Ingredients>();
        _targetIngredients.Add(Ingredients.Green);
        _targetIngredients.Add(Ingredients.Red);
        _targetIngredients.Add(Ingredients.Blue);
        _targetIngredients.Add(Ingredients.Green);
        _targetIngredients.Add(Ingredients.Blue);
    }

    private void FourthCombintionation()
    {
        List<Ingredients> ingredients = new List<Ingredients>();
        _targetIngredients.Add(Ingredients.Green);
        _targetIngredients.Add(Ingredients.Blue);
        _targetIngredients.Add(Ingredients.Blue);
        _targetIngredients.Add(Ingredients.Green);
        _targetIngredients.Add(Ingredients.Blue);
    }

    private void FithCombintionation()
    {
        List<Ingredients> ingredients = new List<Ingredients>();
        _targetIngredients.Add(Ingredients.Red);
        _targetIngredients.Add(Ingredients.Red);
        _targetIngredients.Add(Ingredients.Blue);
        _targetIngredients.Add(Ingredients.Green);
    }
}

public enum Ingredients { Red, Green, Blue }



