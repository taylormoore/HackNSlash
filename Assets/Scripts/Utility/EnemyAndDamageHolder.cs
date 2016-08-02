using UnityEngine;

public class EnemyAndDamageHolder {

	public GameObject enemy;
	public float damage;

	public EnemyAndDamageHolder(GameObject enemy, float damage) {
		this.enemy = enemy;
		this.damage = damage;
	}
}
