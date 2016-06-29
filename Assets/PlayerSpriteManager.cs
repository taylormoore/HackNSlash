using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSpriteManager : NetworkBehaviour {

	public Sprite facingUp, facingDown, facingLeft, facingRight;
	[SyncVar] SpriteRenderer spriteRenderer;

	void Awake() {
		if (isLocalPlayer) {
			spriteRenderer = GetComponent<SpriteRenderer>();
			CmdChangeSprite(facingDown);
		}
	}

	void Update() {
		if (isLocalPlayer) {
			if (PlayerInput.horizontalAxis > .35f) {
				spriteRenderer.sprite = facingRight;
				CmdChangeSprite(facingRight);
			} else if (PlayerInput.horizontalAxis < -.35f) {
				spriteRenderer.sprite = facingLeft;
				CmdChangeSprite(facingLeft);
			}
			if (PlayerInput.verticalAxis > .35f) {
				spriteRenderer.sprite = facingUp;
				CmdChangeSprite(facingUp);
			} else if (PlayerInput.verticalAxis < -.35f) {
				spriteRenderer.sprite = facingDown;
				CmdChangeSprite(facingDown);
			}
		}
	}

	[Command]
	private void CmdChangeSprite(Sprite newSprite) {
		if (spriteRenderer == null)
			return;
		spriteRenderer.sprite = newSprite;
	}
}
