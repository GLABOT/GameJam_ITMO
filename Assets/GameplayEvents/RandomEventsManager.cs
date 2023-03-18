using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventsManager : MonoBehaviour
{
    [SerializeField] private float _timeBetweenEvents;
    private IEnumerator EventCountdown()
    {
        yield return new WaitForSeconds(_timeBetweenEvents);
    }

    private void RandomEvent()
    {
        
    } 
}

[System.Serializable]
public struct GameEvent
{
    public string eventName;
}
