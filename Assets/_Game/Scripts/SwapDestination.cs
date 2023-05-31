using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapDestination : MonoBehaviour
{
    GameObject destination1;
    GameObject destination2;
    GameObject destination3;
    Vector3 tempPosition;

    // Start is called before the first frame update
    void Start()
    {
        destination1 = GameObject.Find("Destination 1");
        destination2 = GameObject.Find("Destination 2");
        destination3 = GameObject.Find("Destination 3");

        Swap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Swap()
    {
        int randomNumber = Random.Range(1, 4);

        tempPosition = destination1.transform.position;

        if (randomNumber == 2)
        {
            destination1.transform.position = destination2.transform.position;
            destination2.transform.position = tempPosition;
        }
        else if (randomNumber == 3)
        {
            destination1.transform.position = destination3.transform.position;
            destination3.transform.position = tempPosition;
        } // if 1 do nothing

    }
}
