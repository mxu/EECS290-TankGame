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
	
		this.rotateCamera(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	
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
		
		tankController.pointGunAt(new Vector3(-currentCameraRotation.x + 55, currentCameraRotation.y, 0f));
	}
	
	/* This helper method changes the camera position to follow with mouse input
	 * @param relativeMSX The relative horizontal mouse speed at a given frame
	 * @param relativeMSY The relative vertical mouse speed at a given frame */
	public void rotateCamera (float relativeMSX, float relativeMSY) {
		Vector3 targetRotation = new Vector3(relativeMSY, relativeMSX, 0f); // Takes the mouse motion and translates it to rotation angles for the camera
		Vector3 temp  = targetRotation + currentCameraRotation;
		float boundary =  temp.x;
		if (boundary < -5) 
			boundary = -5; 
		if (boundary > 25)
			boundary = 25;
		cameraRotater.transform.localRotation = Quaternion.Euler(boundary, temp.y, 0f);
		currentCameraRotation = targetRotation + currentCameraRotation;
	}
}
