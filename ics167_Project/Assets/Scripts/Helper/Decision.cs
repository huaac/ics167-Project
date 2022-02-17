using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// by Aissa Akiyama
/// A decision that lets the Helper FSM decide whether to transition to a new state or not.
/// The Decide method is called in the CheckTransitions() of a State.
/// </summary>

public abstract class Decision : ScriptableObject
{
    public abstract bool Decide(HelperFSM machine);
}