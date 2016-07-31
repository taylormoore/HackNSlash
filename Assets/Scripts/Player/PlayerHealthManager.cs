using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

	[SerializeField]
	int health;

	[SerializeField]
	float takeDamageCooldown;

	float lastDamageTaken;

	public void ApplyDamage(int damage) {
		if (Time.time > lastDamageTaken + takeDamageCooldown) {
			health -= damage;
			lastDamageTaken = Time.time;
		}
	}
}
