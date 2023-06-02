using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //destroy the object a certain amount of time after instantiating
        Destroy(this.gameObject, 0.1f);

        Debug.Log("starting explosion script");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("rocket explosion hit enemy");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            PersistentManagerScript.instance.IncrementScore();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("rocket explosio hit player");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.rigidbody.AddExplosionForce(10,this.gameObject.transform.position, 2);
        }
    }
}
