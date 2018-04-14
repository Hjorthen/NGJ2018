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
    private static readonly float kFLoseCookiePiecePercentage = 0.60f;
    private static readonly float kSLoseCookiePiecePercentage = 0.20f;
    private static readonly float kMinHPPercentage = 0.0f;
    private static readonly int kFLoseCookieIndex = 2;
    private static readonly int kSLoseCookieIndex = 4;

    [SerializeField]
    private GameObject m_PristineCookie;
    [SerializeField]
    private GameObject m_CrackableCookie;
    private GameObject[] m_CookiePieces;
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

    private void MakeCookiePiece(int index)
    {
        GameObject cookiePiece = m_CookiePieces[index];
        if(cookiePiece.transform.parent != null)
        {
            cookiePiece.transform.SetParent(null);
            cookiePiece.AddComponent<CookiePiece>();
        }

    }

    public void Reset()
    {
        m_HPPercentage = kMaxHPPercentage;

        if (m_CrackableCookie != null && m_PristineCookie != null)
        {
            if(m_CookiePieces == null)
            {
                m_CookiePieces = new GameObject[m_CrackableCookie.transform.childCount];

                for (int i = 0; i < m_CookiePieces.Length; ++i)
                    m_CookiePieces[i] = m_CrackableCookie.transform.GetChild(i).gameObject;

            }
            m_CrackableCookie.SetActive(false);
            m_PristineCookie.SetActive(true);
            CurrentDisplayCookie = m_PristineCookie;
        }

    }

    /// <summary>
    /// Takes around 20% hp KAPPA
    /// </summary>
    public void TakeDamage()
    {
        if (m_HPPercentage > kMinHPPercentage)
        {
            m_HPPercentage -= 0.20f;
            if (!m_CrackableCookie.activeSelf)
            {
                m_CrackableCookie.SetActive(true);
                m_PristineCookie.SetActive(false);
                CurrentDisplayCookie = m_CrackableCookie;
            }

            if(m_HPPercentage <= kFLoseCookiePiecePercentage)
            {
                if(m_HPPercentage > kSLoseCookiePiecePercentage)
                    MakeCookiePiece(kFLoseCookieIndex);
                else
                    MakeCookiePiece(kSLoseCookieIndex);
            }
        }

        if (m_HPPercentage <= kMinHPPercentage)
        {
            m_HPPercentage = kMinHPPercentage;
            for (int i = 0; i < m_CookiePieces.Length; ++i)
                MakeCookiePiece(i);
        }
    }


    public void BreakPoint()
    {
        if (m_HPPercentage > kMinHPPercentage)
        {
            m_PristineCookie.SetActive(false);
            m_HPPercentage = kMinHPPercentage;
            for (int i = 0; i < m_CookiePieces.Length; ++i)
                MakeCookiePiece(i);
        }

    }

    public bool isDead()
    {
        return m_HPPercentage == kMinHPPercentage;
    }


}
