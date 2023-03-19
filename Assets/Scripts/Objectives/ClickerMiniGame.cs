using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickerMiniGame : MonoBehaviour
{
    public static ClickerMiniGame instance = null;

    [SerializeField] private Slider m_Slider;
    [SerializeField] private GameObject m_Message;
    [SerializeField] private float _loseTime = 10f;

    private KeyCode _interactionButton = KeyCode.R;
    private float _sumValue = 0.05f;
    private float _loseTimeDelta;

    private string _winMassage = "Good Job!";
    private string _loseMassage = "Not good...";

    private float _exitGameTimer = 1f;

    public bool ClickerStarted;

    private void Start()
    {
        if (instance == null)
            instance = this;


        _loseTimeDelta = _loseTime;
    }

    private void Update()
    {
        if (!ClickerStarted)
            return;

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
            SoundsManager.instance.PlaySound("Good", true);
        }
    }

    private IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(_exitGameTimer);

        m_Message.gameObject.SetActive(false);
        gameObject.SetActive(false);
        Information.instance.HideInfo();
        SoundsManager.instance.PlaySound("Signal", false);
        TimeForQuests.instance.StopTimer();
        CurrentQuest.instance.HideQuest();
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
        SoundsManager.instance.PlaySound("Good", true);
    }

    private void OnDisable()
    {
        _loseTimeDelta = _loseTime;
    }
}
