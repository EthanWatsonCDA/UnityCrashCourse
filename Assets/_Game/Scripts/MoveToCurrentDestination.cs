using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToCurrentDestination : MonoBehaviour
{
    NavMeshAgent agent;
    Transform destinationLocation;
    GameObject destinationObject;




    private void Awake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destinationObject = GameObject.Find("Destination 1");
    }

    // Update is called once per frame
    void Update()
    {
        destinationLocation = destinationObject.transform;
        agent.SetDestination(destinationLocation.position);
    }
}
