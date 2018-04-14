using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTimer {

    private float m_TimeOut = 0;
	// Use this for initialization
	public void Start (float timeOut)
    {
        m_TimeOut = Time.time + timeOut;
	}

    public bool IsDone()
    {
        return Time.time > m_TimeOut;
    }
}
