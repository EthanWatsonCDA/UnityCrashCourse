using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //destroy the object a certain amount of time after instantiating
        Destroy(this.gameObject, 0.05f);

        Debug.Log("starting explosion script");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enemy collision detected");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
