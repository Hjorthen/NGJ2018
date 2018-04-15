using Assets.Scripts.Utilities;
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

    private bool m_DeadLastTick;
    public ParticleSystem crumblePS;

    private SimpleTimer timer;

    private void Start()
    {
        timer = new SimpleTimer();
        breakableCookie.Reset();
        m_DeadLastTick = false;
    }

    private void Update()
    {
        breakableCookie.CurrentDisplayCookie.transform.rotation = physicsCookie.GetFrontWheelRotation() * Quaternion.Euler(Vector3.forward * -90);

        if(!m_DeadLastTick && breakableCookie.isDead())
        {
            Animator anim = TagHelper.GetFirstComponent<Animator>(Tags.DeathScreen);
            anim.SetTrigger("Die");
        }
        m_DeadLastTick = breakableCookie.isDead();
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
