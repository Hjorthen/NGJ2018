using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieController : MonoBehaviour {
    public WheelCollider[] LeftWheels;
    public WheelCollider[] RightWheels;
    public float maxSteeringAngle; 
    void FixedUpdate () {
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        for (int i = 0; i < LeftWheels.Length; i++)
        {
            LeftWheels[i].steerAngle = steering;
        }

        for (int i = 0; i < RightWheels.Length; i++)
        {
            RightWheels[i].steerAngle = steering;
        }
    }
}
