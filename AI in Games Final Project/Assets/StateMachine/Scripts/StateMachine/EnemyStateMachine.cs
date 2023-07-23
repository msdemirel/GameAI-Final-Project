using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Example StateMachine that is used to control the agent in the example scene
/// </summary>
public class EnemyStateMachine : StateMachine
{
    protected override void CreateStates()
    {
        State patrol = new PatrolState(this);
        State chasePlayer = new ChasePlayerState(this);
        currentState = patrol;
        states.Add(patrol);
        states.Add(chasePlayer);
    }
}
