using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ProjectileMovement : NetworkBehaviour {

	[SerializeField]
	float movementSpeed;

    Rigidbody2D rigidBody;

	public enum Direction {left, right, up, down};

	Direction myDirection = Direction.left;

    void OnEnable() {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

	void Update() {

		switch (myDirection) {
			case Direction.left:
                rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
    			transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
    			break;

			case Direction.right:
                rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
    			transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
    			break;

			case Direction.up:
                rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
    			transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
    			break;

			case Direction.down:
                rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
    			transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
    			break;

			default:
                break;
		}	
	}

	[Command]
	public void CmdSetDirection(int direction) {
		switch (direction) {
			case 1:
			myDirection = Direction.left;
			break;

			case 2:
			myDirection = Direction.right;
			break;

			case 3:
			myDirection = Direction.up;
			break;

			case 4:
			myDirection = Direction.down;
			break;

			default:
			Debug.Log("Setting direction failed");
			break;
		}
	}
}
