using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// by Aissa Akiyama
/// 
/// </summary>

[CreateAssetMenu(menuName = "FSM State", order = 52)]
public class State : ScriptableObject
{
    // The action to take while in this state.
    [SerializeField] private Action action;
    [SerializeField] private int animationState;

    // A list of decisions I can make while in this state,
    // and corresponding transitions that I can do from this state.
    [System.Serializable]
    public struct Transition
    {
        public Decision decision;
        public State newState;
    }
    [SerializeField] private Transition[] transitions;

    public void Enter(HelperFSM machine)
    {
        Debug.Log("changing animation");
        machine.Anim.SetInteger("helperState", animationState);
    }

    public void Execute(HelperFSM machine)
    {
        action.Act(machine);
        CheckTransitions(machine);
    }

    // For each possible transition, check if I can actually make that transition,
    // and do so if I can.
    private void CheckTransitions(HelperFSM machine)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            bool canTransition = transitions[i].decision.Decide(machine);

            if (canTransition)
            {
                machine.TransitionState(transitions[i].newState);
            }
        }
    }

    public void Exit(HelperFSM machine) { }
}
