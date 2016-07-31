using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

	[SerializeField]
	int health;

	[SerializeField]
	float takeDamageCooldown;

	float lastDamageTaken;

	PlayerHealthUI playerHealthUI;

	void Start() {
		playerHealthUI = GetComponent<PlayerHealthUI>();
	}

	public void ApplyDamage(int damage) {
		if (Time.time > lastDamageTaken + takeDamageCooldown) {
			health -= damage;
			lastDamageTaken = Time.time;
		}
	}
}
