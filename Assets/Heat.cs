﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heat : MonoBehaviour {

    HealthEffects healthEffects;
    GameObject player;

    private void Start()
    {
        healthEffects = player.GetComponent<HealthEffects>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("Hit heatsource");
            switch (healthEffects.GetCurrentEffect())
            {
                case CookieEffects.Doughed:
                    //Add health
                    print("Added health!");
                    healthEffects.SetCurrentEffect(CookieEffects.None);
                    break;
                case CookieEffects.Wet:
                    print("Dried!");
                    healthEffects.SetCurrentEffect(CookieEffects.None);
                    break;
                case CookieEffects.None:
                    print("Dealt damage!");
                    //Deal damage
                    break;
            }
        }
    }
}
