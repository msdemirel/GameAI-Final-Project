using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inherit this class to create your own States for the StateMachine
/// </summary>
public abstract class State
{
    /// <summary>
    /// The StateMachine instance used to control this State
    /// </summary>
    protected StateMachine stateMachine;

    public State()
    {

    }

    public State(StateMachine s)
    {
        stateMachine = s;
    }


    /// <summary>
    /// Called by the StateMachine on Start
    /// </summary>
    public virtual void OnStart() { }
    /// <summary>
    /// Called by the StateMachine when this state becomes the active state
    /// </summary>
    public virtual void OnEnter() { }
    /// <summary>
    /// Called by the StateMachine when another state becomes the active state
    /// </summary>
    public virtual void OnExit() { }
    /// <summary>
    /// Called by the StateMachine on each Update if this state is active
    /// </summary>
    public virtual void OnUpdate() { }
    /// <summary>
    /// Called by the StateMachine when it is enabled
    /// </summary>
    public virtual void OnEnable() { }
    /// <summary>
    /// Called by the StateMachine when it is disabled
    /// </summary>
    public virtual void OnDisable() { }
    /// <summary>
    /// Called by the StateMachine on each FixedUpdate if this state is active
    /// </summary>
    public virtual void OnFixedUpdate() { }
    /// <summary>
    /// Called by the StateMachine on each LateUpdate if this state is active
    /// </summary>
    public virtual void OnLateUpdate() { }
}
