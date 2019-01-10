using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float forwardSpeed;
	public float turnSpeed;
	private Rigidbody rb;
	public Vector3 forwardVector;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		forwardVector = Vector3.forward;
	}

	void FixedUpdate () 
	{
		// player key movement variables
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// vector from meatball to the camera-facing vector
		Vector3 vel = new Vector3 (rb.velocity.x, 0f, rb.velocity.z).normalized;

		if (rb.velocity != Vector3.zero)
			forwardVector = vel;

		// right vector 90 degrees from forward vector
		Vector3 rightVector = Quaternion.Euler (0, 90, 0) * (forwardVector);

		// vector from the meatball to the direction of the force-to-be-applied
		Vector3 movement = (rightVector * (moveHorizontal) * turnSpeed) + (forwardVector * (moveVertical + 0.1f) * forwardSpeed);

		// apply force
	    rb.AddForce (movement);

		// some visual overlay of vectors
		Debug.DrawRay (transform.position, forwardVector, Color.cyan);
		Debug.DrawRay (transform.position, movement, Color.black);
		Debug.DrawRay (transform.position, rightVector, Color.grey);
		Debug.DrawLine (Camera.main.transform.position, transform.position + (forwardVector * 2f), Color.blue);
	} 
}
 