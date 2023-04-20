using UnityEngine;
using System.Collections;

public class ROTATE_LEFT : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate (new Vector3 (0, 5, 0) * (Time.deltaTime * 2));
	}
}
