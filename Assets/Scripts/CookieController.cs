using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CookieController : MonoBehaviour {
    public WheelCollider[] LeftWheels;
    public WheelCollider[] RightWheels;

    public float maxSteeringAngle;
    public float InitialVelocity;

    [SerializeField]
    private BreakableCookie breakableCookie;
    private Rigidbody m_RigidBody;

    private void Start()
    {
        breakableCookie.Reset();
        m_RigidBody = GetComponent<Rigidbody>();
        for (int i = 0; i < LeftWheels.Length; i++)
        {
            LeftWheels[i].motorTorque = InitialVelocity;
        }

        for (int i = 0; i < RightWheels.Length; i++)
        {
            RightWheels[i].motorTorque = InitialVelocity;
        }
    }

    private void Update()
    {
        Vector3 localVelocity = transform.InverseTransformDirection(m_RigidBody.velocity);
        breakableCookie.CurrentDisplayCookie.transform.Rotate(Vector3.up, m_RigidBody.velocity.z);
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
