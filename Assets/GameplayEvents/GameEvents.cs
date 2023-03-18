using System.Collections;
using UnityEngine;

public class EventsStateMachine : MonoBehaviour
{
    private EventsStateFactory _states;
    private EventsBaseState _currentState;

    public EventsStateFactory Factory { get { return _states; } }
    public EventsBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }

    private void Awake()
    {
        _states = new EventsStateFactory(this);
        _currentState = _states.Idle();
        _currentState.EnterState();
    }

    [SerializeField] private float _timeBetweenEvents;
    private IEnumerator EventCountdown()
    {
        yield return new WaitForSeconds(_timeBetweenEvents);
    }

    private void RandomEvent()
    {

    }

    [System.Serializable]
    public struct GameEvent
    {
        public string eventName;
    }
}
