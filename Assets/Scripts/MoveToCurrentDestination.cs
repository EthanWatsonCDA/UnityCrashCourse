using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToCurrentDestination : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform destinationLocation;

    public LayerMask whatIsGround;

    public GameObject currentDestination;


    private void Awake()
    {
        destinationLocation = GameObject.Find("Destination 1").transform;
        agent = GetComponent<NavMeshAgent>();
    }


    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(destinationLocation.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
