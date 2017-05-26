using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour {

	public int rotationOffset = 0;
	
	// Update is called once per frame
	void Update () {
		
		// Calculate difference between mouse point and camera
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		difference.Normalize ();			// Make all values equal to 1 while keeping correct proportions

		// Calculate the angle between the vector and the x axis and convert to degrees
		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffset);
	}
}
