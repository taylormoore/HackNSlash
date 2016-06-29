using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

	public Sprite facingUp, facingDown, facingLeft, facingRight;
	public float movementSpeed;
	SpriteRenderer spriteRenderer;

	void Start() {
		if (isLocalPlayer) {
			spriteRenderer = GetComponent<SpriteRenderer>();
			Debug.Log("Here, Sprite Renderer: " + spriteRenderer);
		}
	}

	void Update() {
		if (isLocalPlayer && spriteRenderer != null) {
			if (PlayerInput.horizontalAxis > .35f) {
				spriteRenderer.sprite = facingRight;
			} else if (PlayerInput.horizontalAxis < -.35f) {
				spriteRenderer.sprite = facingLeft;
			}
			if (PlayerInput.verticalAxis > .35f) {
				spriteRenderer.sprite = facingUp;
			} else if (PlayerInput.verticalAxis < -.35f) {
				spriteRenderer.sprite = facingDown;
			}
		}
		transform.Translate(Vector2.up * Time.deltaTime * PlayerInput.verticalAxis * movementSpeed);
		transform.Translate(Vector2.right * Time.deltaTime * PlayerInput.horizontalAxis * movementSpeed);
	}
}
