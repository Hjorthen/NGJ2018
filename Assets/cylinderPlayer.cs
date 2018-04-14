using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cylinderPlayer : MonoBehaviour {

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.right * 0.75f * Input.GetAxis("Horizontal"));
        GetComponent<Rigidbody>().AddTorque(transform.right * 10);
    }
}
