﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Aissa Akiyama

[CreateAssetMenu(menuName = "FSM/Actions/Do Nothing", order = 53)]
public class NoAction : Action
{
    public override void Act(HelperFSM machine) { }
}