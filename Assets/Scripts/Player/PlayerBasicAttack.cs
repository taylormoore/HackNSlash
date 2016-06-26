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
                GameObject projectileToShoot = (GameObject) Instantiate(projectile, transform.position, transform.rotation);
                projectileToShoot.GetComponent<ProjectileMovement>().SetDirection(1);
				CmdShootProjectile(projectileToShoot);
                Destroy(projectileToShoot);
                lastAttack = Time.time;
			} else if (PlayerInput.attackRight) {
				GameObject projectileToShoot = (GameObject) Instantiate(projectile, transform.position, transform.rotation);
                projectileToShoot.GetComponent<ProjectileMovement>().SetDirection(2);
                CmdShootProjectile(projectileToShoot);
                Destroy(projectileToShoot);
                lastAttack = Time.time;
			} else if (PlayerInput.attackUp) {
				GameObject projectileToShoot = (GameObject) Instantiate(projectile, transform.position, transform.rotation);
                projectileToShoot.GetComponent<ProjectileMovement>().SetDirection(3);
                CmdShootProjectile(projectileToShoot);
                Destroy(projectileToShoot);
                lastAttack = Time.time;
			} else if (PlayerInput.attackDown) {
				GameObject projectileToShoot = (GameObject) Instantiate(projectile, transform.position, transform.rotation);
                projectileToShoot.GetComponent<ProjectileMovement>().SetDirection(4);
                CmdShootProjectile(projectileToShoot);
                Destroy(projectileToShoot);
                lastAttack = Time.time;
			}
		}
	}

	[Command]
	void CmdShootProjectile(GameObject thisProjectile) {
        GameObject projectileToShoot = (GameObject) Instantiate(thisProjectile, transform.position, transform.rotation);
        Destroy(projectileToShoot, 3f);
	}
}
