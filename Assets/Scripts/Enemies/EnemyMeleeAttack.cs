using UnityEngine;
using System.Collections;

public class EnemyMeleeAttack : MonoBehaviour {

	float lastAttack;
	GameObject nearestPlayer;
	[SerializeField]
	float attackCooldown, attackDamage;

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "Player" && Time.time > attackCooldown + lastAttack) {
			// TODO: Animation for attack
			lastAttack = Time.time;
			other.gameObject.SendMessage("ApplyDamage", attackDamage);
		}
	}
}
