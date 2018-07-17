using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    public bool full = false;

    public bool Full
    {
        get { return full; }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ball" && !full)
        {
            full = true;
        }
        if (Input.GetAxis("Jump") > 0 && full)
            Eject(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball")
        {
            full = false;
        }
    }

    public void Eject(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.AddForce(Random.value * 20, 200f, Random.value * 20);
    }
}
