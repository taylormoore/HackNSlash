using UnityEngine;
using System.Collections;

public class PlayerBasicAttack : MonoBehaviour 
{	
	public GameObject projectile;

	float lastAttack = Time.time;
	float attackCooldown = .4f;

	void Update () {
		if (Time.time > lastAttack + attackCooldown) {
			if (PlayerInput.attackLeft) {
				lastAttack = Time.time;
				GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
				newProjectile.SendMessage("SetDirection", 1);
			} else if (PlayerInput.attackRight) {
				lastAttack = Time.time;
				GameObject  newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
				newProjectile.SendMessage("SetDirection", 2);
			} else if (PlayerInput.attackUp) {
				lastAttack = Time.time;
				GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
				newProjectile.SendMessage("SetDirection", 3);
			} else if (PlayerInput.attackDown) {
				lastAttack = Time.time;
				GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
				newProjectile.SendMessage("SetDirection", 4);
			}
		}
	}
}
