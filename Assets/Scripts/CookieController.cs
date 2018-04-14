using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CookieController : MonoBehaviour
{
    [SerializeField]
    private BreakableCookie m_breakableCookie;
    [SerializeField]
    private PhysicsCookie m_physicsCookie;
    [SerializeField]
    private float m_collisionMagnitudeThreshold;
    [SerializeField]
    private float m_distanceTravelledMultiplier = 1;

    [SerializeField]
    private bool m_debugMode = false;
    private SimpleTimer m_timer;
    private Vector3 m_previousPosition;

    private void Awake()
    {
        m_previousPosition = transform.position;
        m_timer = new SimpleTimer();
        m_breakableCookie.Reset();
    }

    private void Update()
    {
        float distanceTravelled = Vector3.Distance(m_previousPosition, transform.position);
      //  m_breakableCookie.CurrentDisplayCookie.transform.localEulerAngles += new Vector3(360 * distanceTravelled * m_distanceTravelledMultiplier, 0, 0);
    }

    void FixedUpdate()
    {

        if (!m_breakableCookie.isDead())
            m_physicsCookie.Step(Input.GetAxis("Horizontal"));
        else
            m_physicsCookie.Shutdown();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (m_physicsCookie.Velocity.sqrMagnitude >= m_collisionMagnitudeThreshold && m_timer.IsDone())
        {
            m_breakableCookie.TakeDamage();
            m_timer.Start(1);
            if (m_debugMode)
                Debug.Log("Cookie took damage", gameObject);

        }
    }
}
