using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Example State that contains the logic for what happens when the agent is patrolling. Controlled by a StateMachine.
/// </summary>
public class PatrolState : State
{
    private NavigationSystem navigationSystem;
    private DetectionSystem detectionSystem;

    // This constructor is called when a new State object is being created
    public PatrolState(StateMachine s)
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
        // Start patrolling when this state becomes active
        navigationSystem.StartPatrolling();
    }

    public override void OnUpdate()
    {
        // If the agent sees the target, change to ChasePlayerState
        if (detectionSystem.TargetVisible)
        {
            stateMachine.ChangeState(1);
        }
    }

    public override void OnExit()
    {
        // Stop patrolling when another state becomes active
        navigationSystem.StopPatrolling();
    }
}
