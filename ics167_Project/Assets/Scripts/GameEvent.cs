using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Aissa Akiyama
// This class is a generic game event that can be raised from any script and will call things to
// do on each of its listeners. You can make a new game event by making a new instance of this class through
// Create->Game Event like you do for scripts and 3D objects and stuff.

[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event", order = 51)]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();

    // invoke all listeners
    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }


    public void RegisterListener(GameEventListener listener) // 7
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener) // 8
    {
        listeners.Remove(listener);
    }
}
