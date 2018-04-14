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

    public Quaternion GetFrontWheelRotation()
    {
        Vector3 pos;
        Quaternion rot;
        m_LeftWheels[0].GetWorldPose(out pos, out rot);
        return rot;
    }

    private bool m_Ready;
    public void Step(float steeringAxis)
    {
        if (!m_Ready)
            Check();

        float steeringValue = steeringAxis * m_SteeringAngle;

        m_LeftWheels[0].steerAngle = steeringValue;
        m_RightWheels[0].steerAngle = steeringValue;

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
        m_Rigidbody.velocity = Vector3.zero;
        m_Rigidbody.angularVelocity = Vector3.zero;
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
