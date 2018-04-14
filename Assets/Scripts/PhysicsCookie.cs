using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PhysicsCookie {

    [SerializeField]
    private WheelCollider[] m_LeftWheels;
    [SerializeField]
    private WheelCollider[] m_RightWheels;
    [SerializeField]
    private Rigidbody m_Rigidbody;
    [SerializeField]
    private float m_InitialVelocity;
    [SerializeField]
    private float m_SteeringAngle;

    public float InitialVelocity { get { return m_InitialVelocity; } }

    public Vector3 Velocity { get { return m_Rigidbody.velocity; } }
    bool ready;
    public void Step(float steeringAxis)
    {
        if (!ready)
            Check();

        float steeringValue = steeringAxis * m_SteeringAngle;
        for (int i = 0; i < m_LeftWheels.Length; i++)
        {
            m_LeftWheels[i].steerAngle = steeringValue;
        }

        for (int i = 0; i < m_RightWheels.Length; i++)
        {
            m_RightWheels[i].steerAngle = steeringValue;
        }
    }

    void Check()
    {
        if(m_Rigidbody == null && m_LeftWheels.Length == 0 && m_RightWheels.Length == 0)
        {
            throw new UnityException("Missing rigidbody or wheels on gameObject");
        }

        for (int i = 0; i < m_LeftWheels.Length; i++)
        {
            m_LeftWheels[i].motorTorque = InitialVelocity;
        }

        for (int i = 0; i < m_RightWheels.Length; i++)
        {
            m_RightWheels[i].motorTorque = InitialVelocity;
        }

        ready = true;
    }

}
