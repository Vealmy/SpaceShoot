//#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float tumble = 8.0f;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitCircle * tumble;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
//#endif