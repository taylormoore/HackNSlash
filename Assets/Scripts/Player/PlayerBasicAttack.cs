using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerBasicAttack : NetworkBehaviour 
{	
	public GameObject projectile;
	float attackCooldown = .4f;
	float lastAttack = 0f;

	void Update () {
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
	void CmdShootProjectile(int directionID) {
        GameObject projectileToShoot = (GameObject) Instantiate(projectile, transform.position, transform.rotation);
        projectileToShoot.GetComponent<ProjectileMovement>().SetDirection(directionID);
	}
}
