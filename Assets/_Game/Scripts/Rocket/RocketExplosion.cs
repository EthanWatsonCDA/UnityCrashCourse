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

        //rocket jumping
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("rocket explosion hit player");
            other.transform.parent.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000, this.gameObject.transform.position, 2);
        }
    }
}
