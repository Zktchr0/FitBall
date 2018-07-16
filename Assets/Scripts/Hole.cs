using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    bool full = false;
    bool win = false;

    public bool Full
    {
        get { return full; }
    }

    public bool Win
    {
        get { return win; }
        set { win = value; }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ball")
        {
            full = true;
         
            if (Input.GetAxis("Jump") > 0|| win)
                Eject(other);
        }
        else
            full = false;
    }

    public void Eject(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.AddForce(Random.value * 20, 200f, Random.value * 20);
    }
}
