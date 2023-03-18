using UnityEngine;

public class EventsStateFactory : MonoBehaviour
{
        EventsStateMachine _context;

        public EventsStateFactory(EventsStateMachine currentContext)
        {
            _context = currentContext;
        }

        public EventsBaseState Idle()
        {
            return new EventsIdleState(_context, this);
        }

    }
