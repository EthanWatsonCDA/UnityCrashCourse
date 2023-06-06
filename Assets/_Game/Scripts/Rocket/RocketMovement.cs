using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class RocketMovement : MonoBehaviour
{
    public Rigidbody rocket;
    public float rocketSpeed;
    public GameObject rocketExplosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //destroy rocket if it doesn't hit something within a certain amount of time after instantiating
        Destroy(this.gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        //move rocket forward
        rocket.transform.position += transform.forward * Time.deltaTime * rocketSpeed;
    }

    private void OnDestroy()
    {
        Instantiate(rocketExplosionPrefab, rocket.transform.position, rocket.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            Debug.Log("rocket hit detected");
            Destroy(this.gameObject);
        }
    }
}
