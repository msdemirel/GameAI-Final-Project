using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Used by the agent to determine if it can see the target
/// </summary>
public class DetectionSystem : MonoBehaviour
{
    /// <summary>
    /// Transform of the GameObject the agent is trying to detect
    /// </summary>
    public Transform Target;
    /// <summary>
    /// Is the target currently visible
    /// </summary>
    public bool TargetVisible => _targetVisible;

    // How wide is the field of view of the agent. In this simple example the
    // vertical and horizontal field of view are the same
    [SerializeField] private float fieldOfView = 90;
    [SerializeField] private float viewDistance = 5; // How far does the agent see in meters
    [SerializeField] private Transform rayOrigin; // The position of the agents eyes

    private bool _targetVisible = false; // Is the target currently visible

    // We use FixedUpdate for the player detection because the Raycast uses the physics system
    void FixedUpdate()
    {
        // During each FixedUpdate we check if the agent can see the target
        float distance = Vector3.Distance(transform.position, Target.position);
        Vector3 angleFrom = Target.position - transform.position;
        float angle = Vector3.Angle(angleFrom, transform.forward);
        RaycastHit hitInfo;
        Vector3 direction = Target.position - rayOrigin.position;

        if (distance < viewDistance && angle < fieldOfView / 2 &&
            Physics.Raycast(rayOrigin.position, direction, out hitInfo, viewDistance))
        {
            if (hitInfo.collider.gameObject.layer == 7)
            {
                Debug.DrawLine(rayOrigin.position, Target.position, Color.green, 0.1f);
                _targetVisible = true;
            }
            else
            {
                _targetVisible = false;
            }
            
        }
        else
        {
            _targetVisible = false;
        }
    }
}
