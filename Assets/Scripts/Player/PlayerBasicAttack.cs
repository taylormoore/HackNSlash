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

		if (!(Time.time > lastAttack + attackCooldown)) {
			return;
		}

		if (attackLeft) {
			CmdShootProjectile(1, gameObject);
			lastAttack = Time.time;
		} else if (attackRight) {
			CmdShootProjectile(2, gameObject);
			lastAttack = Time.time;
		} else if (attackUp) {
			CmdShootProjectile(3, gameObject);
			lastAttack = Time.time;
		} else if (attackDown) {
			CmdShootProjectile(4, gameObject);
			lastAttack = Time.time;
		}
	}

	[Command]
	public void CmdShootProjectile(int direction, GameObject spawner) {
		RpcDestroyProjectile(direction, spawner);
	}

	[ClientRpc]
	public void RpcDestroyProjectile(int direction, GameObject spawner) {
		GameObject proj;
		if (gameObject == spawner) {
			proj = (GameObject) Instantiate(projectile, transform.position, Quaternion.identity);
			proj.SendMessage("SetReal", true);
		} else {
			proj = (GameObject) Instantiate(projectile, spawner.transform.position, Quaternion.identity);
			proj.SendMessage("SetReal", false);
		}
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
