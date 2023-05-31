using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProximityTrigger : MonoBehaviour
{

    public UnityEvent doOnEnter;
    public UnityEvent doOnExit;
    public UnityEvent doOnStay;

    public void TriggerEntered()
    {
        doOnEnter.Invoke();
    }

    public void TriggerExited()
    {
        doOnExit.Invoke();
    }

    public void TriggerStay()
    {
        doOnStay.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
