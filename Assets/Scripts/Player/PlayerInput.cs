using Rewired;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
	private Player player;

	public static bool inputDisabled, attackRight, attackLeft, attackUp, attackDown = false;
	public static float horizontalAxis, verticalAxis = 0f;

	void Start() {
		player = ReInput.players.GetPlayer(0);
	}

	void Update() {
		DetectMovementInput();
		DetectAttackInput();
	}

	void DetectMovementInput() {
		horizontalAxis = player.GetAxisRaw("MoveHorizontal");

		verticalAxis = player.GetAxisRaw("MoveVertical");
	}

	void DetectAttackInput() {
		if (player.GetAxisRaw("AttackHorizontal") > 0) {
			attackRight = true;
		} else {
			attackRight = false;
		}

		if (player.GetAxisRaw("AttackHorizontal") < 0) {
			attackLeft = true;
		} else {
			attackLeft = false;
		}

		if (player.GetAxisRaw("AttackVertical") > 0) {
			attackUp = true;
		} else {
			attackUp = false;
		}

		if (player.GetAxisRaw("AttackVertical") < 0) {
			attackDown = true;
		} else {
			attackDown = false;
		}
	}
}
