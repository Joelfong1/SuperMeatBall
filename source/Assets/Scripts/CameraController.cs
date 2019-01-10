using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform ballObject;
	public float cameraHeight;
	public float cameraOffsetMul;
	public float zoomSmoothness;
	public float maxYOffset;
	public float minYOffset;
	private PlayerController pc;

	void Start()
	{
		// hide mouse
		//Cursor.lockState = CursorLockMode.Locked;

		// get the script reference to access its variables
		pc = ballObject.GetComponent<PlayerController> ();
	} 
		

	void Update() 
	{
		// calculate camera height based on meatball speed
		float cameraY = cameraHeight / (ballObject.GetComponent<Rigidbody>().velocity.magnitude / zoomSmoothness);
	
		if (cameraY > (maxYOffset)) {
			cameraY = maxYOffset;
		} else if (cameraY < (minYOffset)) {
			cameraY = minYOffset;
		}

		// set camera position (X, Z) at the opposite side of the meatball orthoganol to the velocity vector
		transform.position = new Vector3(-pc.forwardVector.x * (cameraOffsetMul + (pc.forwardSpeed / 7)), cameraY, -pc.forwardVector.z * (cameraOffsetMul + (pc.forwardSpeed / 7))) + ballObject.transform.position;

		// point camera's frustum to the meatball
		transform.LookAt(ballObject.transform.position + (pc.forwardVector * 2f));
	}
}
