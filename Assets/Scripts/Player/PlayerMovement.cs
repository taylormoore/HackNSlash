using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

	public Sprite facingUp, facingDown, facingLeft, facingRight;
	public float movementSpeed;
	SpriteRenderer spriteRenderer;

	void Awake() {
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = facingDown;
	}


	void Update() {
		if (PlayerInput.horizontalAxis > .35f) {
			CmdChangeSprite(facingRight);
		} else if (PlayerInput.horizontalAxis < -.35f) {
			CmdChangeSprite(facingLeft);
		}
		if (PlayerInput.verticalAxis > .35f) {
			CmdChangeSprite(facingUp);
		} else if (PlayerInput.verticalAxis < -.35f) {
			CmdChangeSprite(facingDown);
		}
		transform.Translate(Vector2.up * Time.deltaTime * PlayerInput.verticalAxis * movementSpeed);
		transform.Translate(Vector2.right * Time.deltaTime * PlayerInput.horizontalAxis * movementSpeed);
	}

	[Command]
	private void CmdChangeSprite(Sprite newSprite) {
		spriteRenderer.sprite = newSprite;
	}
}
