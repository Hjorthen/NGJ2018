using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cylinderPlayer : MonoBehaviour {

    private void FixedUpdate()
    {
        //GetComponent<Rigidbody>().AddForce(Vector3.right * 0.25f);
        GetComponent<Rigidbody>().AddForce(transform.forward);
    }
}
