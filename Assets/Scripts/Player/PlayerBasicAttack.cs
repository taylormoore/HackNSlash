using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerBasicAttack : NetworkBehaviour 
{	
	public GameObject projectile;

	float lastAttack = Time.time;
	float attackCooldown = .4f;

	void Update () {
		if (Time.time > lastAttack + attackCooldown) {
			if (PlayerInput.attackLeft) {
				CmdShootProjectile(1);
			} else if (PlayerInput.attackRight) {
				CmdShootProjectile(2);
			} else if (PlayerInput.attackUp) {
				CmdShootProjectile(3);
			} else if (PlayerInput.attackDown) {
				CmdShootProjectile(4);
			}
			lastAttack = Time.time;
		}
	}

	[Command]
	void CmdShootProjectile(int directionID) {
		GameObject newProjectile = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
		newProjectile.SendMessage("CmdSetDirection", directionID);
		Destroy(newProjectile, 3.0f);
		NetworkServer.Spawn(newProjectile);
	}
}
