using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CookieController : MonoBehaviour {

    [SerializeField]
    private BreakableCookie breakableCookie;
    [SerializeField]
    private PhysicsCookie physicsCookie;

    private void Start()
    {
        breakableCookie.Reset();
    }

    private void Update()
    {
        breakableCookie.CurrentDisplayCookie.transform.Rotate(Vector3.up, physicsCookie.Velocity.z);
    }


    void FixedUpdate() {

        physicsCookie.Step(Input.GetAxis("Horizontal"));     
    }
}
