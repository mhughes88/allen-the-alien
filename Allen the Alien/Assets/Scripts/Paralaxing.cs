using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaxing : MonoBehaviour {

	public Transform[] 	backgrounds;						// Array of all elements to be parallaxed
	private float[]		parallaxScales;						// The proportion of the camera's movement to move the backgrounds by
	public float		smoothing = 1f;						// How smooth the parallax is going to be. Make sure to set this above 0

	private Transform 	cam; 								// Reference to the main camera's transform
	private Vector3		prevCamPos;							// Store the position of the camera in the previous frame

	// Is called before Start()
	void Awake () {
		
		// Set up the camera reference
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		
		// Set the previous frame to the camera's current position
		prevCamPos = cam.position;

		parallaxScales = new float[backgrounds.Length];

		// Assigning coresponding parallaxScales
		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z * -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		// For each background
		for (int i = 0; i < backgrounds.Length; i++) {

			// The parallax is the opposite of the camera movement because the previous frame is multiplied by the scale
			float parallax = (prevCamPos.x - cam.position.x) * parallaxScales[i];

			// Set a target x position which is the current position plus the parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			// Create a target position which is the background's current position with it's target x position
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			// Fade between current position and the target position using lerp
			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}

		// Set the prevCamPos to the camera's position at the end of the frame
		prevCamPos = cam.position;
	}
}
