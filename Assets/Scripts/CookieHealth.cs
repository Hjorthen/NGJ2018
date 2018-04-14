using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieHealth : MonoBehaviour {

    public float health = 100;

	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            KillCookie();
        }
	}

    void KillCookie()
    {
        print("Thats The Way The Cookie Crumbles...");
    }

    public void DealDamage(float damage)
    {
        health -= damage;
    }
}
