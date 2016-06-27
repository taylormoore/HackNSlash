using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class EnemyStatus : NetworkBehaviour {

	[SyncVar(hook="SetHealth")]
    public int enemyHealth;

    EnemyUI enemyUI;

    void OnEnable() {
        enemyUI = GetComponent<EnemyUI>();
        enemyUI.SetHealthUI(enemyHealth);
    }

    public void SetHealth(int health) {
        enemyHealth = health;
        enemyUI.SetHealthUI(enemyHealth);
    }

	public void ApplyDamage(int value) {
        enemyHealth -= value;
        enemyUI.SetHealthUI(enemyHealth);
        if (enemyHealth <= 0) {
            Debug.Log("sup ladies");
            NetworkServer.Destroy(gameObject);
        }
	}

	public int GetHealth() {
		return enemyHealth;
	}
}
