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
    private bool m_Ready;
    public void Step(float steeringAxis)
    {
        if (!m_Ready)
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

        if(steeringAxis  == 0)
        {
           m_Rigidbody.velocity = m_Rigidbody.transform.InverseTransformDirection(Vector3.Lerp(m_Rigidbody.transform.TransformDirection(m_Rigidbody.velocity), Vector3.forward, 0.15f));
           m_Rigidbody.rotation = Quaternion.RotateTowards(m_Rigidbody.rotation, Quaternion.LookRotation(Vector3.forward), 20);
        }

        Debug.DrawRay(m_Rigidbody.position, m_Rigidbody.velocity * 20, Color.green);
    }

    public void Shutdown()
    {
        if (m_Rigidbody == null && m_LeftWheels.Length == 0 && m_RightWheels.Length == 0)
            return;

        for (int i = 0; i < m_LeftWheels.Length; i++)
        {
            m_LeftWheels[i].motorTorque = 0;
            m_LeftWheels[i].steerAngle = 0;
        }

        for (int i = 0; i < m_RightWheels.Length; i++)
        {
            m_RightWheels[i].motorTorque = 0;
            m_RightWheels[i].steerAngle = 0;

        }

        m_Ready = false;
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

        m_Ready = true;
    }

}
