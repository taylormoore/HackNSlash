using Rewired;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

	public Sprite facingUp, facingDown, facingLeft, facingRight;
	public float movementSpeed;
	Animator animator;
	private Player player;
	private float horizontalAxis, verticalAxis = 0f;

	void Start() {
		if (isLocalPlayer) {
			animator = GetComponent<Animator>();
		}
		player = ReInput.players.GetPlayer(0);
	}

	void Update() {
		DetectMovementInput();

		if (isLocalPlayer && animator != null) {
			if (horizontalAxis > .35f) {
				animator.SetInteger("direction", 1);
			} else if (horizontalAxis < -.35f) {
				animator.SetInteger("direction", 0);
			}
			if (verticalAxis > .35f) {
				animator.SetInteger("direction", 2);
			} else if (verticalAxis < -.35f) {
				animator.SetInteger("direction", 3);
			}
		}
		transform.Translate(Vector2.up * Time.deltaTime * verticalAxis * movementSpeed);
		transform.Translate(Vector2.right * Time.deltaTime * horizontalAxis * movementSpeed);
	}

	void DetectMovementInput() {
		horizontalAxis = player.GetAxisRaw("MoveHorizontal");
		verticalAxis = player.GetAxisRaw("MoveVertical");
	}
}
