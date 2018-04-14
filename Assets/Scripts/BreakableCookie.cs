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
    private GameObject m_PristineCookie;
    [SerializeField]
    private GameObject m_CrackableCookie;

    public GameObject CurrentDisplayCookie { get; private set; }

    public GameObject PristineCookie
    {
        get { return m_PristineCookie; }
    }

    public GameObject CrackableCookie
    {
        get { return m_CrackableCookie; }
    }
    public BreakableCookie()
    {
        Reset();
    }

    public void SetCookies(GameObject pristine, GameObject crackable)
    {
        m_PristineCookie = pristine;
        CurrentDisplayCookie = m_PristineCookie;
        m_CrackableCookie = crackable;
    }


    public void Reset()
    {
        m_HPPercentage = kMaxHPPercentage;

        if (m_CrackableCookie != null && m_PristineCookie != null)
        {
            m_CrackableCookie.SetActive(false);
            m_PristineCookie.SetActive(true);
            CurrentDisplayCookie = m_PristineCookie;
        }

    }

    /// <summary>
    /// Takes around 15% hp KAPPA
    /// </summary>
    public void TakeDamage()
    {
        if (m_HPPercentage > kMinHPPercentage)
        {
            m_HPPercentage -= 0.15f;
            if (!m_CrackableCookie.activeSelf)
            {
                m_CrackableCookie.SetActive(true);
                m_PristineCookie.SetActive(false);
                CurrentDisplayCookie = m_CrackableCookie;
            }
        }

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
