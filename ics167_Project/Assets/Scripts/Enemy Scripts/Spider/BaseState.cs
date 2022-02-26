using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// added in by Alice Hua
// Taken from https://youtu.be/-VkezxxjsSE
public class BaseState : ScriptableObject
{
    public string name;
    protected StateMachine stateMachine;

    public BaseState(string name, StateMachine stateMachine)
    {
        this.name = name;                   // name of state
        this.stateMachine = stateMachine;   // calls og script that deals with the states
    }

    public virtual void Enter() {}
    public virtual void UpdateLogic() {}    // mimics update
    public virtual void UpdatePhysics() {}  // mimics late update
    public virtual void Exit() {}
}
