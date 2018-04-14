using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawDough : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("Player is doughed");
            other.GetComponent<HealthEffects>().SetCurrentEffect(CookieEffects.Doughed);
        }
    }

}
