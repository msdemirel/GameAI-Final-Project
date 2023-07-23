using UnityEngine;

public class Monitor : MonoBehaviour
{
    //public float playerDetectionRange = 10f; 
    private Vector3 lastKnownPlayerPosition = Vector3.zero;
    public bool hasPlayerInfo;
    public GameObject player;

    
    private void Update()
    {
        lastKnownPlayerPosition = player.transform.position;
        Debug.Log(lastKnownPlayerPosition);
    }

    // Provide the last known player's location to the enemy
    public Vector3 GetLastKnownPlayerPosition()
    {
        return lastKnownPlayerPosition;
    }
    
}
