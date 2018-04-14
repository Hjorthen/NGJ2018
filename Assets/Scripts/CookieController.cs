using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CookieController : MonoBehaviour
{

    [SerializeField]
    private bool DebugMode = false;
    [SerializeField]
    private BreakableCookie breakableCookie;
    [SerializeField]
    private PhysicsCookie physicsCookie;
    [SerializeField]
    private float collisionMagnitudeThreshold;

    public ParticleSystem crumblePS;

    private SimpleTimer timer;

    private void Start()
    {
        timer = new SimpleTimer();
        breakableCookie.Reset();
    }

    private void Update()
    {
        breakableCookie.CurrentDisplayCookie.transform.Rotate(transform.up, physicsCookie.Velocity.z);
    }


    void FixedUpdate()
    {

        if (!breakableCookie.isDead())
            physicsCookie.Step(Input.GetAxis("Horizontal"));
        else
            physicsCookie.Shutdown();
    }

    void OnCollisionEnter(Collision collision)
    {
        float sqrMag = physicsCookie.Velocity.sqrMagnitude;
        if (sqrMag >= collisionMagnitudeThreshold && timer.IsDone())
        {
            if (sqrMag >= collisionMagnitudeThreshold * 2)
                breakableCookie.BreakPoint();
            else
                breakableCookie.TakeDamage();

            timer.Start(1);

            crumblePS.Emit(30);

            if (DebugMode)
                Debug.Log("Cookie took damage", gameObject);

        }
    }
}
