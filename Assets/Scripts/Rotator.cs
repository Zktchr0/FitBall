﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// a rotator for the camera
/// </summary>
public class Rotator : MonoBehaviour {

    public float speed = 12f;
    private float turnInputValue;

    void Update () {
        turnInputValue = Input.GetAxis("Rotate");
        float turn = turnInputValue * speed * Time.deltaTime;
        transform.Rotate(0f, turn, 0f);
    }

}
