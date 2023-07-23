using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Example State that contains the logic for what happens when the agent is chasing the player. Controlled by a StateMachine.
/// </summary>
public class ChasePlayerState : State
{
    private NavigationSystem navigationSystem;
    private DetectionSystem detectionSystem;

    // This constructor is called when a new State object is being created
    public ChasePlayerState(StateMachine s)
    {
        stateMachine = s;
    }

    public override void OnStart()
    {
        // Initialize references to the required AI systems
        navigationSystem = stateMachine.gameObject.GetComponent<NavigationSystem>();
        detectionSystem = stateMachine.gameObject.GetComponent<DetectionSystem>();
    }


    public override void OnEnter()
    {
        // Start moving towards the target when this state becomes active
        navigationSystem.SetDestination(detectionSystem.Target.position);
    }

    public override void OnUpdate()
    {
        // If target is visible, navigate towards it
        if (detectionSystem.TargetVisible)
        {
            navigationSystem.SetDestination(detectionSystem.Target.position);
        }
        // Othewise change to PatrolState
        else
        {
            stateMachine.ChangeState(0);
        }
    }
}
