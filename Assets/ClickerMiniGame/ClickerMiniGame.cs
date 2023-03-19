using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickerMiniGame : MonoBehaviour
{
    [SerializeField] private Slider m_Slider;
    [SerializeField] private GameObject m_Message;
    [SerializeField] private float _loseTime = 10f;

    private KeyCode _interactionButton = KeyCode.O;
    private float _sumValue = 0.05f;
    private float _loseTimeDelta;

    private string _winMassage = "Хорошая работа!";
    private string _loseMassage = "Неудача..";

    private float _exitGameTimer = 1f;

    private void Start()
    {
        _loseTimeDelta = _loseTime;
    }

    private void Update()
    {
        InputCheck();

        if (m_Slider.value == 1)
        {
            Win();
        }

        _loseTimeDelta -= Time.deltaTime;

        if (_loseTimeDelta <= 0f)
        {
            Lose();
        }
    }

    private void InputCheck()
    {
        if (Input.GetKeyDown(_interactionButton))
        {
            m_Slider.value += _sumValue;
        }
    }

    private IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(_exitGameTimer);

        m_Message.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    private void Lose()
    {
        m_Message.gameObject.SetActive(true);
        m_Message.GetComponentInChildren<Text>().text = _loseMassage;
        StartCoroutine(ExitGame());
    }
    
    private void Win()
    {
        m_Message.gameObject.SetActive(true);
        m_Message.GetComponentInChildren<Text>().text = _winMassage;
        StartCoroutine(ExitGame());
    }

    private void OnDisable()
    {
        _loseTimeDelta = _loseTime;
    }
}
