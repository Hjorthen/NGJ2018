using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BreakableCookie {

    public float HPPercentage
    {
        get { return m_HPPercentage; }
    }

    [SerializeField]
    private float m_HPPercentage;
    private static readonly float kMaxHPPercentage = 1.0f;
    private static readonly float kMinHPPercentage = 0.0f;

    [SerializeField]
    private GameObject pristineCookie;
    [SerializeField]
    private GameObject crackableCookie;

    public BreakableCookie()
    {

    }

    public void SetCookies(GameObject pristine, GameObject crackable)
    {
        pristineCookie = pristine;
        crackableCookie = crackable;
    }


    public void Reset()
    {
        m_HPPercentage = kMaxHPPercentage;
    }

    /// <summary>
    /// Takes around 15% hp KAPPA
    /// </summary>
    public void TakeDamage()
    {
        if (m_HPPercentage > kMinHPPercentage)
            m_HPPercentage -= 0.15f;

        if (m_HPPercentage < kMinHPPercentage)
            m_HPPercentage = kMinHPPercentage;
    }

    public void BreakPoint()
    {
        m_HPPercentage = kMinHPPercentage;
    }

    public bool isDead()
    {
        return m_HPPercentage == kMinHPPercentage;
    }


}
