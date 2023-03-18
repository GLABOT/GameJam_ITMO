public abstract class EventsBaseState
{
    private bool _isRootState = false;
    private EventsStateMachine _context;
    private EventsStateFactory _factory;
    public EventsBaseState _currentSubState;
    private EventsBaseState _currentSuperState;

    public bool IsRootState { set { _isRootState = value; } }
    public EventsStateMachine Context { get { return _context; } }
    public EventsStateFactory Factory { get { return _factory; } }
    public EventsBaseState CurrentSubState { get { return _currentSubState; } }

    public EventsBaseState(EventsStateMachine currentContext, EventsStateFactory playerStateFactory)
    {
        _context = currentContext;
        _factory = playerStateFactory;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchStates();
    public abstract void InitializeSubState();

    public void UpdateStates()
    {
        UpdateState();
        if (_currentSubState != null)
        {
            _currentSubState.UpdateStates();
        }
    }

    protected void SwitchState(EventsBaseState newState)
    {
        ExitState();

        newState.EnterState();

        if (_isRootState)
        {
            _context.CurrentState = newState;
        }
        else if (_currentSuperState != null)
        {
            _currentSuperState.SetSubState(newState);
        }
    }

    protected void SetSuperState(EventsBaseState newSuperState)
    {
        _currentSuperState = newSuperState;
    }

    protected void SetSubState(EventsBaseState newSubState)
    {
        _currentSubState = newSubState;
        newSubState.SetSuperState(this);
    }
    protected void SetSubStateAndEnter(EventsBaseState newSubState)
    {
        _currentSubState.ExitState();

        _currentSubState = newSubState;
        newSubState.SetSuperState(this);

        _currentSubState.EnterState();
    }
}
