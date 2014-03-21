using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	TankController tankController;
	GameObject cameraRotater;
	Vector3 currentCameraRotation = new Vector3(0f, 0f, 0f);
	
	void Start() {
		tankController = this.GetComponent<TankController>();
		cameraRotater = GameObject.Find ("CameraRotater");
	}
	
	
	void Update () {
	
		this.rotateCamera(Input.GetAxis("Horizontal"));
	
		if (Input.GetKey (KeyCode.W)) {
			tankController.moveForward();
		}
		if (Input.GetKey (KeyCode.S)) {
			tankController.moveBackward();
		}
		if (Input.GetKey (KeyCode.A)) {
			tankController.turnLeft();
		}
		if (Input.GetKey (KeyCode.D)) {
			tankController.turnRight();
		}
		if (Input.GetKeyDown (KeyCode.Space)){
			tankController.shoot();
		}
		
		tankController.pointGunAt(currentCameraRotation);
	}
	
	// This helper method changes the camera position to follow with mouse input
	public void rotateCamera (float relativeMS) {
		Vector3 targetRotation = new Vector3(0f, relativeMS, 0f);
		cameraRotater.transform.localRotation = Quaternion.Euler(targetRotation + currentCameraRotation);
		currentCameraRotation = targetRotation + currentCameraRotation;
	}
}
