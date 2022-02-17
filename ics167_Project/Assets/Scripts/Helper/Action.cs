using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// by Aissa Akiyama
/// An action that the Helper FSM does while in a certain state.
/// The Act method is called in the Execute() of a State.
/// </summary>

public abstract class Action : ScriptableObject
{
    public abstract void Act(HelperFSM machine);
}