using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}
