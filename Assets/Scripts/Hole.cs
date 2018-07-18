using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The Hole class - for checking whether the holes is empty or not,
/// plus the Eject ball method
/// </summary>
public class Hole : MonoBehaviour {

    public bool full = false;

    public bool Full
    {
        get { return full; }
    }

    // setting the hole to full when the ball is inside, and allowing Eject
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ball" && !full)
        {
            full = true;
        }
        if (Input.GetAxis("Jump") > 0 && full)  // ejecting the ball, if the hole is full and the Jump button is pressed
            Eject(other);
    }

    // setting the hole back to empty if the ball exits
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball")
        {
            full = false;
        }
    }

    // pushing the ball up in a random direction
    public void Eject(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.AddForce(Random.value * 40, 200f, Random.value * 40);
    }
}
