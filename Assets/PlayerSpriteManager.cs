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
	}

	[Command]
	private void CmdChangeSprite(Sprite newSprite) {
		if (spriteRenderer == null)
			return;

		spriteRenderer.sprite = newSprite;
	}
}
