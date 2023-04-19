using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLR : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 5, 5) * (Time.deltaTime * 33));
    }
}
