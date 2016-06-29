using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerBasicAttack : NetworkBehaviour {
	public GameObject projectile;
	float attackCooldown = .4f;
	float lastAttack = 0f;

	void Update() {
		if (Time.time > lastAttack + attackCooldown) {
			if (PlayerInput.attackLeft) {
				CmdShootProjectile(1);
				lastAttack = Time.time;
			} else if (PlayerInput.attackRight) {
				CmdShootProjectile(2);
				lastAttack = Time.time;
			} else if (PlayerInput.attackUp) {
				CmdShootProjectile(3);
				lastAttack = Time.time;
			} else if (PlayerInput.attackDown) {
				CmdShootProjectile(4);
				lastAttack = Time.time;
			}
		}
	}

	[Command]
	public void CmdShootProjectile(int direction) {
		GameObject thisProjectile = (GameObject) Instantiate(projectile, transform.position, transform.rotation);
		thisProjectile.SendMessage("UpdateDirection", direction);
		Destroy(thisProjectile, 3f);
		NetworkServer.Spawn(thisProjectile);
	}
}
