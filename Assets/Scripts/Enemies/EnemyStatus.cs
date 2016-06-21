using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class EnemyStatus : NetworkBehaviour {

	[SyncVar(hook="SetHealth")]
    private int enemyHealth;

    EnemyUI enemyUI;

    void Awake() {
        enemyHealth = 500;
        enemyUI = GetComponent<EnemyUI>();
        enemyUI.SetHealthUI(enemyHealth);
    }

    public void SetHealth(int health) {
        enemyHealth = health;
        enemyUI.SetHealthUI(enemyHealth);
    }

    void OnBecameInvisible() {
        enemyUI.SetHealthUI(enemyHealth);
    }

	public void ApplyDamage(int value) {
        enemyHealth -= value;
        Debug.Log("Enemy Health: " + enemyHealth);
        enemyUI.SetHealthUI(enemyHealth);
        if (enemyHealth < 0) {
            NetworkServer.Destroy(gameObject);
        }
	}

	public int GetHealth() {
		return enemyHealth;
	}
}
