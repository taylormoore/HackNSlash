using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

	public float movementSpeed;

	void Update() {
		transform.Translate(Vector2.up * Time.deltaTime * PlayerInput.verticalAxis * movementSpeed);
		transform.Translate(Vector2.right * Time.deltaTime * PlayerInput.horizontalAxis * movementSpeed);
	}
}
