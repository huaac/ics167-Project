using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// by Aissa Akiyama
// This class is a generic listener script for game events.
// The gameEvent field specifies what game event this listener will be listening to.
// The response field specifies what function in what object will be called when the game event
// is raised. This works a lot like the OnClick(), OnValueChanged, etc that Unity's UI system uses.

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private UnityEvent response;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        response.Invoke();
    }
}
