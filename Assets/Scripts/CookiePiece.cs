using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookiePiece : MonoBehaviour {

    private static readonly float kScriptExpireTime = 0.20f;
    private SimpleTimer timer;

	// Use this for initialization
	void Start () {

        timer = new SimpleTimer();
        StartCoroutine(SleepCoroutine());
	}

    IEnumerator SleepCoroutine()
    {
        timer.Start(kScriptExpireTime);
        while (!timer.IsDone())
        {

            yield return new WaitForSeconds(Time.deltaTime);
        }
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(Time.deltaTime * transform.InverseTransformDirection(rb.position));
        GetComponent<MeshCollider>().enabled = true;
        Destroy(this);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
