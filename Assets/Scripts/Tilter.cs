using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilter : MonoBehaviour {

    const float speed = 2f;
    float horizontal = 0f;
    float vertical = 0f;
    const float RotationLimit = 25f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            Tilt(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        else if (Input.GetMouseButton(0))
            Tilt(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    void Tilt(float xMovement, float yMovement)
    {
        horizontal = Mathf.Clamp(horizontal + -xMovement * speed, -RotationLimit, RotationLimit);
        vertical = Mathf.Clamp(vertical + yMovement * speed, -RotationLimit, RotationLimit);
        transform.eulerAngles = new Vector3(vertical, 0f, horizontal);
    }
}
