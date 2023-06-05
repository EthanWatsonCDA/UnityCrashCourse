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
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("rocket explosion hit enemy");
            Destroy(other.gameObject);
            PersistentManagerScript.instance.IncrementScore();
            PersistentManagerScript.instance.DecrementNumEnemies();
        }

        
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("rocket explosion hit player");
            other.GetComponent<Rigidbody>().AddExplosionForce(10, this.gameObject.transform.position, 2);
        }
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("rocket explosion hit player");
            collision.rigidbody.AddExplosionForce(10, this.gameObject.transform.position, 2);
        }
    }
    */
}
