using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// by Aissa Akiyama
/// A class that describes a FSM state that the Helper can be in.
/// A State is described by 1) the Action the Helper does while in this state,
/// 2) the animation to play while in this state, and 3) a finite set of transitions that
/// can be made from this state. Each transition is described by a Decision that triggers
/// the transition when it evaluates to true, and the new State that the Helper will transition to.
/// </summary>

[CreateAssetMenu(menuName = "FSM State", order = 52)]
public class State : ScriptableObject
{
    // The action to take while in this state.
    [SerializeField] private Action action;

    // This state's animation.
    [System.Serializable]
    public enum animationState { idle, running, attack, stop };
    [SerializeField] private animationState animState;

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
        machine.Anim.SetInteger("helperState", (int)animState);
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
                break;
            }
        }
    }

    public void Exit(HelperFSM machine) { }
}