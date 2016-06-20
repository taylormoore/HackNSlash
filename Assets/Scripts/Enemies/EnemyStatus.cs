using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class EnemyStatus : NetworkBehaviour {

	[SyncVar]
	private int enemyHealth;

    float damageCooldown = 2f;
    float lastDamageTaken;

    void Start() {
        lastDamageTaken = Time.time;
    }

	public void ApplyDamage(int value) {
        if (Time.time > lastDamageTaken + damageCooldown) {
            lastDamageTaken = Time.time;
            enemyHealth -= value;
            Debug.Log("Enemy Health: " + enemyHealth);
        }
	}

	public int GetHealth() {
		return enemyHealth;
	}
}
