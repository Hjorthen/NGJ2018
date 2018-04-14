using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("Player is wet");
            other.GetComponent<HealthEffects>().SetCurrentEffect(CookieEffects.Wet);
        }
    }
}
