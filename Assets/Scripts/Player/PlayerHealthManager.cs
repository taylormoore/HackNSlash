using UnityEngine;
using UnityEngine.Networking;

public class PlayerHealthManager : NetworkBehaviour {

	[SerializeField]
	[SyncVar (hook ="SetHealth")]
	int health;

	[SerializeField]
	float takeDamageCooldown;

	float lastDamageTaken;

	PlayerHealthUI playerHealthUI;

	void Start() {
		playerHealthUI = GetComponent<PlayerHealthUI>();
		PlayerReference.RefreshPlayersUI();
	}

	public void ApplyDamage(int damage) {
		if (Time.time > lastDamageTaken + takeDamageCooldown) {
			health -= damage;
			lastDamageTaken = Time.time;
		}
	}

	public void UpdateHealthUI() {
		SetHealth(health);
	}

	public void SetHealth(int newHealth) {
		health = newHealth;
		playerHealthUI.SetHealthUI(health);
	}
}
