﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CookieController : MonoBehaviour {

    [SerializeField]
    private bool DebugMode = false;
    [SerializeField]
    private BreakableCookie breakableCookie;
    [SerializeField]
    private PhysicsCookie physicsCookie;
    public float collisionMagnitudeThreshold;
    private SimpleTimer timer;
    private void Start()
    {
        timer = new SimpleTimer();
        breakableCookie.Reset();
    }

    private void Update()
    {
        breakableCookie.CurrentDisplayCookie.transform.Rotate(Vector3.up, physicsCookie.Velocity.z);
    }


    void FixedUpdate() {

        if (!breakableCookie.isDead())
            physicsCookie.Step(Input.GetAxis("Horizontal"));
        else
            physicsCookie.Shutdown();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (physicsCookie.Velocity.sqrMagnitude >= collisionMagnitudeThreshold && timer.IsDone())
        {
            breakableCookie.TakeDamage();
            timer.Start(1);
            if (DebugMode)
                Debug.Log("Cookie took damage", gameObject);
            
        }
    }
}
