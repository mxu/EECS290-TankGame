using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
	
	
	public Vector3 torque = new Vector3(0f, 100f, 0f);
	public Rigidbody[] leftWheels;
	public Rigidbody[] rightWheels;
	public GameObject turret;
	public Transform gun;
	public Transform gunRotationPoint;
	public Transform shootSpot;
	public float gunPitchLowBound;
	public float gunPitchHighBound;
	public float gunTurnSpeed;
	public float shootSpeed;
	public Vector3 turnTo;
	public GameObject bullet;
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		this.moveGunTowards(turnTo);
		
		
		
	}
	
	
	public void shoot(){ 
		GameObject datBullet = (GameObject) GameObject.Instantiate(bullet);
		datBullet.transform.position = shootSpot.position;
		datBullet.transform.rotation = Quaternion.Euler(shootSpot.rotation.eulerAngles + new Vector3(90f, 0f, 0f));
		datBullet.rigidbody.velocity = Vector3.Cross(datBullet.transform.forward, new Vector3(1f, 0f, 0f)) * shootSpeed;
		
	}
	
	//ToDo: Make the gun turret lerp and shit and make the gun not turn outside of the bounds.
	private void moveGunTowards(Vector3 direction){
		float pitchOfset = gunRotationPoint.rotation.eulerAngles.y - gun.localRotation.eulerAngles.x;
		Debug.Log(pitchOfset);
		
		
		Vector3 rotation = new Vector3 (0f, direction.x, 90f);
		float newY = direction.y;
		if (newY > gunPitchHighBound)
			newY = gunPitchHighBound;
		if (newY < gunPitchLowBound)
			newY = gunPitchLowBound;
		Vector3 pitch = new Vector3(90f, newY, 0f);
		Vector3 currentPitch = new Vector3 (90f, gun.localRotation.y, 0f);
		Vector3 currentRotation = new Vector3 (0f, gunRotationPoint.rotation.y, 90f);
		gun.localRotation = Quaternion.Euler(pitch);
		gunRotationPoint.rotation = Quaternion.Euler(rotation);
				
	
		/*This bit is a little weird. The way I made the gun rotate was by using 
		a spherical coordinate system and updating the position of the gun such
		that it is always on the correct spot on the outside of the tank. I am
		sure there are better ways to do this but none that worked for me. */
		
		
		
		
		float turretRadius = 2f * turret.transform.localScale.x / 3f;
		float gunLength = gun.localScale.y;
		float theta = (gun.rotation.eulerAngles.y - 90f) * Mathf.Deg2Rad;
		float phi = gun.rotation.eulerAngles.z * Mathf.Deg2Rad;
		gunRotationPoint.position = turret.transform.position;
		gun.position = turret.transform.position + 
			new Vector3(
				turretRadius * Mathf.Sin (phi) * Mathf.Sin(theta), 
				turretRadius * Mathf.Cos(phi),  
				turretRadius * Mathf.Sin (phi) * Mathf.Cos(theta)
				);
	}
	
	
	
	/*All these methods are just used to move and turn the tank.
	Moving forward and backwards is just done by applying the appropriate torque
	to the wheels, and turning is done by applying opposite torque to the left
	and right wheels appropriately */
	
	
	public void moveForward() {
		foreach (Rigidbody rb in leftWheels){
			rb.AddRelativeTorque(-torque);
		}
		foreach (Rigidbody rb in rightWheels){
			rb.AddRelativeTorque(-torque);
		}
	}
	
	public void moveBackward(){
		foreach (Rigidbody rb in leftWheels){
			rb.AddRelativeTorque(torque);
		}
		foreach (Rigidbody rb in rightWheels){
			rb.AddRelativeTorque(torque);
		}
	}
	
	public void turnRight(){
		foreach (Rigidbody rb in leftWheels){
			rb.AddRelativeTorque(-torque);
		}
		foreach (Rigidbody rb in rightWheels){
			rb.AddRelativeTorque(torque);
		}
	}
	
	public void turnLeft(){
		foreach (Rigidbody rb in leftWheels){
			rb.AddRelativeTorque(torque);
		}
		foreach (Rigidbody rb in rightWheels){
			rb.AddRelativeTorque(-torque);
		}
	}
}
