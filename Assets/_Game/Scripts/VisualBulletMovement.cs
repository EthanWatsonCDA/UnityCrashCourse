using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class VisualBulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.forward * Time.deltaTime * 500f;
    }
}
