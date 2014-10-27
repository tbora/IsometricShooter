using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public Rigidbody projectile;
	public GameObject gameOver;
	public GameObject target;
	public TextMesh Score;
	public int playerScore;

	private Vector3 playerStartPos;
	private Vector3 hasABlockUnder;

	private Vector3 rightUp;
	private Vector3 leftUp;
	private Vector3 rightDown;
	private Vector3 leftDown;

	private Vector3 leftSide;
	private Vector3 rightSide;
	
	void Start () {
		playerStartPos = new Vector3(-3, -2, 0);
		hasABlockUnder = new Vector3(1, 0, 0);

		//ups
		rightUp = new Vector3(1, 1, 0);
		leftUp = new Vector3(0, 1, 1);

		//downs
		rightDown = new Vector3(0, -1, -1);
		leftDown = new Vector3(-1, -1, 0);

		//left
		leftSide = new Vector3(-1, 0, 1);

		//right
		rightSide = new Vector3(1 ,0, -1);

		playerScore = 0;

	}

	void Update () {

		Score.text = playerScore.ToString();

		if(Input.GetKeyDown(KeyCode.A)){
			if(isFree(KeyCode.A)){
				transform.Translate(leftSide);
			}
		}

		else if(Input.GetKeyDown(KeyCode.D)) {
			if(isFree(KeyCode.D)){
				transform.Translate(rightSide);
			}
		}

		else if(Input.GetKeyDown(KeyCode.W)) {
			if(isFree(KeyCode.W)){
				transform.Translate(leftUp);
			}
		}

		else if(Input.GetKeyDown(KeyCode.S)){
			if(isFree(KeyCode.S)){
				transform.Translate(rightDown);
			}
		}

		else if(Input.GetKeyDown(KeyCode.Space)){
			Rigidbody clone;
			clone = Instantiate(projectile, transform.position+new Vector3(0,1f, 0), transform.rotation) as Rigidbody;
			clone.AddRelativeForce (new Vector3(0, 400f, 0));
			clone.gameObject.collider.enabled = true;
		}

	}

	 private bool isFree(KeyCode playerPressed){

		bool isFree = true;

		foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[]){
			if(gameObj.name.Contains("Cube")){

				if(playerPressed == KeyCode.A){
					if(gameObj.transform.position == transform.position + leftSide){
						isFree = false;
					}
				}

				if(playerPressed == KeyCode.D){
					if(gameObj.transform.position == transform.position + rightSide){
						isFree = false;
					}
				}

				if(playerPressed == KeyCode.W){
					if(gameObj.transform.position == transform.position + leftUp){
						isFree = false;
					}
				}

				if(playerPressed == KeyCode.S){
					if(gameObj.transform.position == transform.position + rightDown){
						isFree = false;
					}
				}

			}
		}

		if(isFree){return true;}
		else{return false;}

	}

}
