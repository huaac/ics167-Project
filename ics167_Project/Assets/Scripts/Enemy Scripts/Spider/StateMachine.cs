using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// added in / edited by Alice Hua
// Taken from https://youtu.be/-VkezxxjsSE
// this is the base class for the spider FSM which inherits from Killable Enemy
public class StateMachine : KillableEnemy
{
    BaseState currentState;

    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();
    }

    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
    }

    void LateUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    public void ChangeState(BaseState newState)
    {
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }
}
