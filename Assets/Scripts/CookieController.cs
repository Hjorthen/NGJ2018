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

    private SimpleTimer m_DmgTimer;
    private SimpleTimer m_warmupTimer;

    private void Start()
    {
        m_DmgTimer = new SimpleTimer();
        m_warmupTimer = new SimpleTimer();
        m_warmupTimer.Start(2);
        breakableCookie.Reset();
        m_DeadLastTick = false;
    }

    private void Update()
    {
        Quaternion WorldUP = Quaternion.Euler(Vector3.up);
        float angle = Quaternion.Angle(WorldUP, transform.rotation);

        if(m_warmupTimer.IsDone() && physicsCookie.Velocity.sqrMagnitude < 1)
        {
            breakableCookie.BreakPoint();
        }

        if (angle > 90 || angle < -90)
            breakableCookie.BreakPoint();

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
        if (sqrMag >= collisionMagnitudeThreshold && m_DmgTimer.IsDone())
        {
            if (sqrMag >= collisionMagnitudeThreshold * 2)
                breakableCookie.BreakPoint();
            else
                breakableCookie.TakeDamage();

            m_DmgTimer.Start(1);

            crumblePS.Emit(30);


            GetComponent<AudioSource>().Play();


            if (DebugMode)
                Debug.Log("Cookie took damage", gameObject);

        }
    }
}
