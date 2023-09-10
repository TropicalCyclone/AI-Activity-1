using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AmogusPatrol : MonoBehaviour
{
    [SerializeField] private GameObject WaypointList;
    [SerializeField] private NavMeshAgent agent;
    public GameObject targetWayPoint;
    [SerializeField] public List<Transform> myWaypoints;
    bool isMoving;
    [SerializeField] private int waypointNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (WaypointList != null)
        {
            foreach (Transform t in WaypointList.GetComponentInChildren<Transform>())
            {
                myWaypoints.Add(t.transform);
            }
        }
        PickRandomWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    PickRandomWaypoint();
                }
            }
        }
    }

    private void PickRandomWaypoint()
    {
        if(myWaypoints.Count == 0)
        {
            Debug.LogWarning("no Waypoints");
            
                return;
        }


        int WaypointIndex = GetRandomWaypointIndex();
        
        if(WaypointIndex != waypointNumber)
        {
            waypointNumber = WaypointIndex;
            SetDestination(myWaypoints[waypointNumber]);
            //agent.SetDestination(myWaypoints[waypointNumber].position);
        }
        else
        {
            PickRandomWaypoint();
        }
    }


    public int GetRandomWaypointIndex()
    {
        return Random.Range(0, myWaypoints.Count);
    }

    private void SetDestination(Transform Input)
    {
        if (agent != null)
        {
            agent.SetDestination(Input.position);
        }
    }
}
