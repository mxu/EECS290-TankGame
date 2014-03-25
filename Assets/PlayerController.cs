using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	TankController tankController;
	public GameObject cameraRotater;
	Vector3 currentCameraRotation = new Vector3(0f, 0f, 0f);
	
	void Start() {
		tankController = this.GetComponent<TankController>();
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
		Vector3 temp = new Vector3((((-currentCameraRotation.x + 25f)/(30f))*55f)+10f, currentCameraRotation.y, 0f);
		tankController.pointGunAt(temp);
	}
	
	/* This helper method changes the camera position to follow with mouse input
	 * @param relativeMSX The relative horizontal mouse speed at a given frame
	 * @param relativeMSY The relative vertical mouse speed at a given frame */
	public void rotateCamera (float relativeMSX, float relativeMSY) {
		Vector3 targetRotation = new Vector3(relativeMSY, relativeMSX, 0f); // Takes the mouse motion and translates it to rotation angles for the camera
		float boundary =  currentCameraRotation.x + targetRotation.x;
		if (boundary < -5 && relativeMSY < 0) {
			boundary = -5;
			targetRotation = new Vector3(0f, targetRotation.y);
		}
		if (boundary > 25 && relativeMSY > 0) {
			boundary = 25;
			targetRotation = new Vector3(0f, targetRotation.y);
		}
		Vector3 temp  = targetRotation + currentCameraRotation;
		cameraRotater.transform.localRotation = Quaternion.Euler(boundary, temp.y, 0f);
		currentCameraRotation = targetRotation + currentCameraRotation;
	}
}
