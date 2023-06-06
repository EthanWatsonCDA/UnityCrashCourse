using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{

    ProximityTrigger parentTrigger;

    private void OnTriggerEnter(Collider other)
    {
        parentTrigger.TriggerEntered();
        Debug.Log("trigger entered 1");
    }

    private void OnTriggerExit(Collider other)
    {
        parentTrigger.TriggerExited();
    }

    private void OnTriggerStay(Collider other)
    {
        parentTrigger.TriggerStay();
    }

    // Start is called before the first frame update
    void Start()
    {
        parentTrigger = GetComponentInParent<ProximityTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
