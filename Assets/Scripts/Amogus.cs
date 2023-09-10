using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Amogus : MonoBehaviour
{
    [SerializeField] private GameObject WaypointA;
    [SerializeField] private GameObject WaypointB;
    [SerializeField] private NavMeshAgent agent;
    private GameObject CurrentWaypoint;
    public bool amongus = true;
    // Start is called before the first frame update
    void Start()
    {
        SetDestination(WaypointA);
        if(amongus.Equals(true))
        {
            Debug.Log("Sus"); 
        }
    }
 

    // Update is called once per frame
    void Update()
    {
        if (CurrentWaypoint != WaypointA && CurrentWaypoint != WaypointB)
        {
            return;
        }
        if (agent.remainingDistance < 1f)
        {
            if (CurrentWaypoint == WaypointA)
            {
                SetDestination(WaypointB);
            }
            else
            {
                SetDestination(WaypointA);
            }
        }
    }

    private void SetDestination(GameObject Input)
    {
        if(agent != null)
        {
            CurrentWaypoint = Input;
            agent.SetDestination(Input.transform.position);
        }
    }
}
