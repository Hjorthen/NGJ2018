using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollowObject : MonoBehaviour {
    [SerializeField]
    GameObject target;

    public Vector3 offset;
    public float lerp;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {      
        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime*lerp) + offset;
	}
}
