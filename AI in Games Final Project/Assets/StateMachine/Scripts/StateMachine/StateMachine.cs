using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inherit this class to create your own StateMachines
/// </summary>
public abstract class StateMachine : MonoBehaviour
{
    /// <summary>
    /// Reference to the currently active state
    /// </summary>
    protected State currentState;
    /// <summary>
    /// Contains all the states of the StateMachine
    /// </summary>
    public List<State> states = new List<State>();


    /// <summary>
    /// Changes the active state of the StateMachine
    /// </summary>
    /// <param name="index">Index of the state that will become the active state</param>
    public void ChangeState(int index)
    {
        // Make sure that the provided index is valid
        if (states.Count > index)
        {
            currentState.OnExit();
            currentState = states[index];
            currentState.OnEnter();
        }
    }

    /// <summary>
    /// Initializes all the States of the StateMachine
    /// </summary>
    protected abstract void CreateStates();

    protected virtual void Start()
    {
        CreateStates(); // Initialize States

        // Throw an error if no states were added to the StateMachine
        if (states.Count == 0)
        {
            throw new ArgumentException("You did not specify any states. Create at least one state inside the CreateStates method.");
        }

        // Run the OnStart method for each State
        foreach (State state in states)
        {
            state.OnStart();
        }

        // If the active state is not yet specified, default to the first state
        if (currentState == null)
        {
            Debug.Log("Initial state not set. Defaulting to first state inside states array.");
            currentState = states[0];
        }

        // Run the OnEnter for the initial State
        currentState.OnEnter();
    }

    protected virtual void Update()
    {
        currentState.OnUpdate();
    }

    protected void LateUpdate()
    {
        currentState.OnLateUpdate();
    }

    protected virtual void FixedUpdate()
    {
        currentState.OnFixedUpdate();
    }

    protected virtual void OnEnable()
    {
        foreach (State state in states)
        {
            state.OnEnable();
        }
    }

    protected virtual void OnDisable()
    {
        foreach (State state in states)
        {
            state.OnDisable();
        }
    }
}
