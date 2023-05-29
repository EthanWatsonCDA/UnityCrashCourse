using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToCurrentDestination : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform currentDestination;

    public LayerMask whatIsGround;


    private void Awake()
    {
        currentDestination = GameObject.Find("current destination").transform;
        agent = GetComponent<NavMeshAgent>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
