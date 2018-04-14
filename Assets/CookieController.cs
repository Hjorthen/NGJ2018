﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CookieController : MonoBehaviour {
    public WheelCollider[] LeftWheels;
    public WheelCollider[] RightWheels;
    public GameObject Renderer;
    public float maxSteeringAngle;

    private Rigidbody m_RigidBody;

    private void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Renderer.transform.Rotate(Vector3.up, m_RigidBody.velocity.magnitude);
    }


    void FixedUpdate() {
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
