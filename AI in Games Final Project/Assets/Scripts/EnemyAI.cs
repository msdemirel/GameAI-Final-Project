using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //public int timeInSeconds = 0;
    //public int phaseNumber = 0;
    public NavMeshAgent agent;

    private float _delay = 10;

    //Enemy detection systems
    public FieldOfView fov;

    //Enemy state: roaming
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public PlayerHealth playerHealthCount;


    private void Awake()
    {
        fov.target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        if (fov.canSeePlayer == false)
        {
            Patrol();
        }
        if (fov.canSeePlayer == true)
        {
            Chase();
        }


    }

    private void Patrol()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void Chase()
    {
        agent.SetDestination(fov.target.position);
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, fov.groundMask))
        {
            walkPointSet = true;

        }
        else
        {
            SearchWalkPoint();
        }
    }
    public void FixedUpdate()
    {
        if (_delay > 0)
        {
            _delay -= Time.fixedDeltaTime;

            if (_delay <= 0)
            {
                // do something, it has been 10 seconds
                SearchWalkPoint();
                _delay = 10;
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        PlayerHealth playerHealth = collider.gameObject.GetComponent<PlayerHealth>();
        if (collider.gameObject.name == "Player")
        {

            playerHealth.HealthCount();

            Destroy(this.gameObject);
        }
    }

}
//public class EnemyAI : MonoBehaviour
//{
//    //public int timeInSeconds = 0;
//    //public int phaseNumber = 0;
//    public NavMeshAgent agent;

//    private float _delay = 10;

//    //Enemy detection systems
//    public FieldOfView fov;

//    //Enemy state: roaming
//    public Vector3 walkPoint;
//    bool walkPointSet;
//    public float walkPointRange;

//    public PlayerHealth playerHealthCount;

//    public float maxTimeWithoutSeeingPlayer = 5f;
//    private float timeWithoutSeeingPlayer = 0f;

//    public Transform[] monitors;

//    bool reachedMonitor;
//    private Vector3 lastKnownPlayerPosition = Vector3.zero;

//    private void Awake()
//    {
//        fov.target = GameObject.Find("Player").transform;
//        agent = GetComponent<NavMeshAgent>();
//    }


//    private void Update()
//    {
//        if (fov.canSeePlayer)
//        {
//            timeWithoutSeeingPlayer = 0f;
//            Chase();
//        }
//        else
//        {

//            timeWithoutSeeingPlayer += Time.deltaTime;

//            if (timeWithoutSeeingPlayer >= maxTimeWithoutSeeingPlayer)
//            {

//                GoToNearestScreen();
//            }
//            else if (reachedMonitor)
//            {

//                if (lastKnownPlayerPosition != Vector3.zero)
//                {
//                    GetPlayerLocationandSetDestination();

//                    agent.SetDestination(lastKnownPlayerPosition);
//                }
//                else
//                {

//                    Patrol();
//                }
//            }
//            else
//            {
//                Patrol();
//            }
//        }
//    }

//    private void GetPlayerLocationandSetDestination()
//    {
//        if (monitors.Length == 0)
//        {
//            Debug.LogError("No screens found! Please assign screens in the inspector.");
//            return;
//        }


//        foreach (Transform screen in monitors)
//        {
//            Vector3 playerLocation = screen.GetComponent<Monitor>().GetLastKnownPlayerPosition();


//            if (playerLocation != Vector3.zero)
//            {
//                lastKnownPlayerPosition = playerLocation;
//                agent.SetDestination(lastKnownPlayerPosition);
//                Debug.Log("Setting destination to player location from screens.");
//                reachedMonitor = false; 
//                return; 
//            }
//        }
//    }

//    private void GoToNearestScreen()
//    {
//        if (monitors.Length == 0)
//        {
//            return;
//        }

//        Transform nearestMonitor = null;
//        float nearestDistance = float.MaxValue;
//        foreach (Transform screen in monitors)
//        {
//            float distance = Vector3.Distance(transform.position, screen.position);
//            if (distance < nearestDistance)
//            {
//                nearestDistance = distance;
//                nearestMonitor = screen;
//            }
//        }
//        if (nearestMonitor != null)
//        {
//            agent.SetDestination(nearestMonitor.position);
//            Debug.Log("Going to monitor");
//        }
//    }

//    private void Patrol()
//    {
//        if (!walkPointSet) SearchWalkPoint();

//        if (walkPointSet)
//            agent.SetDestination(walkPoint);

//        Vector3 distanceToWalkPoint = transform.position - walkPoint;

//        if (distanceToWalkPoint.magnitude < 1f)
//            walkPointSet = false;
//    }

//    private void Chase()
//    {
//        agent.SetDestination(fov.target.position);
//    }

//    private void SearchWalkPoint()
//    {
//        float randomZ = Random.Range(-walkPointRange, walkPointRange);
//        float randomX = Random.Range(-walkPointRange, walkPointRange);

//        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

//        if (Physics.Raycast(walkPoint, -transform.up, 2f, fov.groundMask))
//        {
//            walkPointSet = true;

//        }
//        else
//        {
//            SearchWalkPoint();
//        }
//    }
//    public void FixedUpdate()
//    {
//        if (_delay > 0)
//        {
//            _delay -= Time.fixedDeltaTime;

//            if (_delay <= 0)
//            {
//                // do something, it has been 10 seconds
//                SearchWalkPoint();
//                _delay = 10;
//            }
//        }
//    }

//    private void OnTriggerEnter(Collider collider)
//    {
//        PlayerHealth playerHealth = collider.gameObject.GetComponent<PlayerHealth>();
//        if (collider.gameObject.name == "Player")
//        {

//            playerHealth.HealthCount();

//            Destroy(this.gameObject);
//        }

//        if (collider.CompareTag("Monitor"))
//        {
//            reachedMonitor = true;
//            Debug.Log("collider entered to monitor");
//        }
//    }

//}
