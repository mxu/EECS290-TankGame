using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public enum MoveState {
        forward = 0,
        left = 1,
        right = 2
    }

	private TankController tankController;
	public GameObject player;

    private float moveTime = 0f;
    private float reloadTime = 0f;
	private float distance = 0f;
    private MoveState movement = MoveState.forward;
	private GameObject[] targets;

    public float aggroRadius = 20f;
    public float attackAngle = 4f;
    public float visionAngle = 10f;
    public float maximumRotateSpeed = 40;
    public float minimumTimeToReachTarget = 0.5f;
    public float _velocity;
    
	// Use this for initialization
	void Start() {
		tankController = this.GetComponentInChildren<TankController>();
		player = GameObject.FindGameObjectWithTag("Player");

		if (this.gameObject.tag.Equals ("Enemy")){
			targets = GameObject.FindGameObjectsWithTag("Player");
		}
		else{
			targets = GameObject.FindGameObjectsWithTag("Enemy");
		}
	}
	
	// Update is called once per frame
	void Update() {

			distance = Vector3.Distance(player.transform.position, transform.position);


		if (targets.Length > 0){
			distance = Vector3.Distance (targets[0].transform.position, transform.position);
			player = targets[0];
		}

		foreach(GameObject target in targets){
			Debug.Log (transform + "'s Target is  " + target);
			if (Vector3.Distance(target.transform.position, transform.position) < distance){
				player = target;
				distance = Vector3.Distance(target.transform.position, transform.position);
				Debug.Log ("Distance: " + distance);
			}
		}

        //distance = (player.transform.position - this.transform.position).magnitude;
		// Use Vector3.Distance(position1, position2), magnitude involves costly square root calculations
        if(distance < aggroRadius) {
			Debug.Log ("Player in range.");
            var a = Quaternion.LookRotation(player.transform.position - transform.position).eulerAngles;
            var b = this.transform.eulerAngles;
            var rd = (a - b).y;
            if(Mathf.Abs(rd) > attackAngle) {
                Debug.Log("Turning to face player");
                this.transform.rotation = Quaternion.Euler(b.x, Mathf.SmoothDampAngle(b.y, a.y, ref _velocity, minimumTimeToReachTarget, maximumRotateSpeed), b.z);
            }
            if(Mathf.Abs(rd) < visionAngle) {
                if(reloadTime < 0.01f) {
                    Debug.Log("Shooting");
					Debug.Log (transform + "'s Target is  " + player);
                    tankController.shoot();
                    reloadTime = 1f;
                } else {
                    reloadTime -= Time.deltaTime;
                }
            }
        } else if(moveTime > 0f) {
            switch(movement) {
                case MoveState.forward:
                    tankController.moveForward();
                    break;
                case MoveState.left:
                    tankController.turnLeft();
                    break;
                case MoveState.right:
                    tankController.turnRight();
                    break;
                default:
                    break;
            }
            moveTime -= Time.deltaTime;
        } else {
            movement = (MoveState) Random.Range(0, 3);
            switch(movement) {
                case MoveState.forward:
                    moveTime = Random.Range(5f, 20f);
                    break;
                case MoveState.left:
                case MoveState.right:
                    moveTime = Random.Range(1f, 7f);
                    break;
                default:
                    break;
            }
        }
    }
}