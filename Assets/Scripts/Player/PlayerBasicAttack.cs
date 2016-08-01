using Rewired;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBasicAttack : NetworkBehaviour {
	public GameObject projectile;
	public GameObject thisProjectile;
	float attackCooldown = .4f;
	float lastAttack = 0f;

	private Player player;
	private bool attackRight, attackLeft, attackUp, attackDown = false;

	void Start() {
		player = ReInput.players.GetPlayer(0);
	}

	void Update() {
		DetectAttackInput();

		if (Time.time > lastAttack + attackCooldown == false) {
			return;
		}

		if (attackLeft) {
			CmdShootProjectile(1);
			lastAttack = Time.time;
		} else if (attackRight) {
			CmdShootProjectile(2);
			lastAttack = Time.time;
		} else if (attackUp) {
			CmdShootProjectile(3);
			lastAttack = Time.time;
		} else if (attackDown) {
			CmdShootProjectile(4);
			lastAttack = Time.time;
		}
	}

	[Command]
	public void CmdShootProjectile(int direction) {
		RpcShootProjectile(direction);
	}

	[ClientRpc]
	public void RpcShootProjectile(int direction) {
		GameObject proj;
		proj = (GameObject) Instantiate(projectile, transform.position, Quaternion.identity);
		proj.SendMessage("SetReal", isLocalPlayer);
		proj.SendMessage("UpdateDirection", direction);
		Destroy(proj, 3f);
	}

	void DetectAttackInput() {
		attackRight = player.GetAxisRaw("AttackHorizontal") > 0;
		attackLeft = player.GetAxisRaw("AttackHorizontal") < 0;
		attackUp = player.GetAxisRaw("AttackVertical") > 0;
		attackDown = player.GetAxisRaw("AttackVertical") < 0;
	}
}
