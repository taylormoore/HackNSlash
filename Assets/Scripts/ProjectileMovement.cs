using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ProjectileMovement : NetworkBehaviour {

	[SerializeField]
	float movementSpeed;

	[SyncVar]
	int myDirection;

	public void UpdateDirection(int direction) {
		myDirection = direction;
	}

	void FixedUpdate() {

		switch (myDirection) {
			case 1:
				transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
				break;

			case 2:
				transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
				break;

			case 3:
				transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
				break;

			case 4:
				transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
				break;

			default:
				break;
		}
	}
}
