using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody rb;
    const float MagneticForce = 15f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Magnet")
        {
            Vector3 target = other.transform.position;
            Vector3 offsetToTarget = other.transform.position - transform.position;
            float distanceToTarget = offsetToTarget.sqrMagnitude;
            rb.AddForce(offsetToTarget*(1/distanceToTarget)*MagneticForce);
        }
    }
}
