using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

	private List<Vector3> m_positions; 

	public GameObject Target;
	public ParticleSystem explosionCubes;
	public TextMesh Score;
	public GameObject Player;
	public GameObject gameOver;

	public bool setTarget;

	void Start() {
		setTarget = false;

		m_positions = new List<Vector3> {
			new Vector3(0, 18, 0),
			new Vector3(-1, 17, 0),
			new Vector3(0, 17, -1),
			new Vector3(-2, 16, 0),
			new Vector3(-1, 16, -1),
			new Vector3(0, 16, -2),
			new Vector3(-1, 15, -2),
			new Vector3(-3, 15, 0),
			new Vector3(-4, 14, 0),
			new Vector3(-3, 14, -1),
			new Vector3(-2, 14, -2),
			new Vector3(-1, 14, -3),
			new Vector3(0, 14, -4),
		};
	}

	void Update() {
		if(rigidbody.velocity.y >  -2.4f){
			rigidbody.AddRelativeForce (new Vector3(0, -2.4f, 0));
		}
	}

	void OnCollisionEnter(Collision col) {

		if(col.gameObject.name.Equals("Bullet(Clone)")){
			GameObject cloneEnemy = Instantiate(gameObject, GetRandomPosition(), Quaternion.identity) as GameObject;
			Player.GetComponent<InputManager>().playerScore += 25;

			Destroy (gameObject);
			Destroy(col.gameObject);

			ParticleSystem ex;
			ex = Instantiate(explosionCubes, gameObject.transform.position, Quaternion.identity) as ParticleSystem;
			ex.particleSystem.Emit(10);


		}


		if(col.gameObject.name.Equals("Cube") || col.gameObject.name.Equals("Player")){
			gameObject.SetActive(false);
			Destroy (Player);
			ParticleSystem ex;

			ex = Instantiate(explosionCubes, gameObject.transform.position, Quaternion.identity) as ParticleSystem;
			ex.particleSystem.Emit(10);
			gameOver.SetActive(true);

		}


	}

	void OnBecameVisible() {
		setTarget = true;
	}

	Vector3 GetRandomPosition() {
		Vector3 position = m_positions[Random.Range(0, m_positions.Count)];
		m_positions.Remove(position);
		return position;
	}
}
