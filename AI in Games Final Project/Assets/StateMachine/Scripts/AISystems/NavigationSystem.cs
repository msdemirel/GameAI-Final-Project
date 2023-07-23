using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
/// <summary>
/// Handles the NavMesh navigation of an AI agent
/// </summary>
public class NavigationSystem : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints; // The waypoints defines a set of positions on the NavMesh that the agent travels trough
    private NavMeshAgent agent; // Used to move the agent on the NavMesh
    private int currentIndex = 0; // The index of the current patrol waypoint the agent is travelling towards 
    private bool isPatrolling = false; // If true, the agent will follow the path defined in the waypoints List

    // We initialize the references at Awake
    void Awake()
    {
        // Initialize the reference to the NavMesh component
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set a new patrol destination for the agent if it is currently patrolling and has reached its current destination
        if (!agent.hasPath && isPatrolling)
        {
            if (currentIndex == waypoints.Count - 1)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }
            agent.SetDestination(waypoints[currentIndex].position);
        }
        
    }

    public void StartPatrolling()
    {
        agent.SetDestination(waypoints[currentIndex].position);
        isPatrolling = true;
        agent.isStopped = false;
    }

    public void StopPatrolling()
    {
        isPatrolling = false;
        agent.isStopped = true;
    }
    
    public void SetDestination(Vector3 worldPosition)
    {
        agent.isStopped = false;
        agent.SetDestination(worldPosition);
        isPatrolling = false;
    }
}
