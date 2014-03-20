using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	TankController tankController;
	
	void Start() {
		tankController = this.GetComponent<TankController>();
	}
	
	
	void Update () {
	
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
		
		
	}
	
	
	
}
